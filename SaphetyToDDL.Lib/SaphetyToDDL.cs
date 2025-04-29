using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using AutoMapper;
using SaphetyToDDL.Lib.Models;
using SaphetyToDDL.Lib.Models.Saphety;

namespace SaphetyToDDL.Lib
{
    /// <summary>
    /// Class responsible for parsing Saphety invoices and mapping them to ItemTransaction objects.
    /// </summary>
    public class SaphetyToDDL
    {
        #region "Enums"

        /// <summary>
        /// The type of document being parsed.
        /// </summary>
        public enum DocumentType
        {
            Invoice = 1,
            CreditNote = 4
        }

        #endregion

        #region "Constants"

        //private const string _documentTypeInvoice = "Invoice";
        //private const string _documentTypeCreditNote = "CreditNote";
        private const string _infoUnrecognizedDocumentType = "Unrecognized document type";

        #endregion

        #region "Properties"

        /// <summary>
        /// The parsed InvoiceType object.
        /// </summary>
        public Invoice ItemTransactionSaphety { get; set; }
        /// <summary>
        /// The parsed ItemTransaction object.
        /// </summary>
        public ItemTransaction ItemTransaction { get; set; }
        public DocumentType ItemTransactionSaphetyDocumentType { get; set; } = DocumentType.Invoice;

        #endregion

        #region "Public"

        /// <summary>
        /// Parses a file containing a Saphety invoice and maps it to an ItemTransaction object.
        /// </summary>
        /// <param name="fileToParse">The XML file content to parse.</param>
        /// <returns>An ItemTransaction object representing the parsed invoice.</returns>
        public ItemTransaction ParseFromFile(string file)
        {
            return Parse(File.ReadAllText(file));
        }

        /// <summary>
        /// Parses a string containing a Saphety invoice and maps it to an ItemTransaction object.
        /// </summary>
        /// <param name="fileToParse">The XML file content to parse.</param>
        /// <returns>An ItemTransaction object representing the parsed invoice.</returns>
        public ItemTransaction Parse(string fileContent)
        {
            MapperConfiguration config = null;
            XDocument doc = XDocument.Parse(fileContent);
            XElement root = doc.Root;

            // Initialize invoice object
            Invoice invoice = null;

            XAttribute attr = root.Attribute("docTypeId");
            string docTypeId = attr != null ? attr.Value : null;
            if (!Enum.TryParse(docTypeId, out DocumentType documentType))
                throw new InvalidOperationException(_infoUnrecognizedDocumentType);

            var serializer = new XmlSerializer(typeof(Invoice));
            using (var reader = new StringReader(fileContent))
            {
                invoice = (Invoice)serializer.Deserialize(reader);
            }
            ItemTransactionSaphetyDocumentType = documentType;

            //// Load the XML based on the root element
            //if (root.Name.LocalName.ToLower() == DocumentType.Invoice.ToString().ToLower() || root.Name.LocalName.ToLower() == DocumentType.CreditNote.ToString().ToLower())
            //{
            //    var serializer = new XmlSerializer(typeof(Invoice));
            //    using (var reader = new StringReader(fileContent))
            //    {
            //        invoice = (Invoice)serializer.Deserialize(reader);
            //    }                
            //    ItemTransactionSaphetyDocumentType = DocumentType.Invoice;
            //}
            //else
            //    throw new InvalidOperationException(_infoUnrecognizedDocumentType);

            // Configure AutoMapper mappings
            switch (ItemTransactionSaphetyDocumentType)
            {
                case DocumentType.Invoice:
                case DocumentType.CreditNote:
                    config = MapInvoice();
                    break;
                default:
                    break;
            }

            // Map the InvoiceType object to an ItemTransaction object
            var itemTransaction = config.CreateMapper().Map<ItemTransaction>(invoice);

            ItemTransactionSaphety = invoice;
            ItemTransaction = itemTransaction;

            return itemTransaction;
        }

        #endregion

        #region "Private"

        /// <summary>
        /// Maps an InvoiceType object to an ItemTransaction object.
        /// </summary>
        /// <returns>The mapper configuration</returns>
        private MapperConfiguration MapInvoice()
        {
            // Configure AutoMapper mappings
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Invoice, ItemTransaction>()
                    .ForMember(destination => destination.CreateDate, opt => opt.MapFrom(src => src.DocumentDates.DocumentDate))
                    .ForMember(destination => destination.DeferredPaymentDate, opt => opt.MapFrom(src => src.DocumentDates.DueDate))
                    .ForMember(destination => destination.ContractReferenceNumber, opt => opt.MapFrom(src => src.DocumentReferences.OrderReference))
                    .ForMember(destination => destination.TotalAmount, opt => opt.MapFrom(src => src.DocumentTotals.TotalNetAmount))
                    .ForMember(destination => destination.TotalTransactionAmount, opt => opt.MapFrom(src => src.DocumentTotals.TotalAmountPayable))
                    //.ForMember(destination => destination.TotalGlobalDiscountAmount, opt => opt.MapFrom(src => src.LegalMonetaryTotal.AllowanceTotalAmount.Value))
                    .ForPath(destination => destination.Party, opt => opt.MapFrom(src => MapParty(src.PartyInformation.Buyer)))
                    .ForPath(destination => destination.CustomerParty, opt => opt.MapFrom(src => MapParty(src.PartyInformation.Buyer)))
                    .ForPath(destination => destination.SupplierParty, opt => opt.MapFrom(src => MapParty(src.PartyInformation.Seller)))
                    .ForPath(destination => destination.UnloadPlaceAddress, opt => opt.MapFrom(src => MapUnloadPlaceAddress(src.PartyInformation.ShipTo)))
                    .ForPath(destination => destination.Details, opt => opt.MapFrom(src => MapInvoiceLines(src.LineItems)))
                    .ForAllOtherMembers(opt => opt.Ignore()); // Ignore all other members, including methods
            });
        }

        ///// <summary>
        ///// Maps a CreditNoteType object to an ItemTransaction object.
        ///// </summary>
        ///// <returns>The mapper configuration</returns>
        //private MapperConfiguration MapCreditNote()
        //{
        //    // Configure AutoMapper mappings
        //    return new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<CreditNote, ItemTransaction>()
        //            .ForMember(destination => destination.CreateDate, opt => opt.MapFrom(src => src.IssueDate.Value.DateTime))
        //            //.ForMember(destination => destination.DeferredPaymentDate, opt => opt.MapFrom(src => src.DueDate.Value.DateTime))
        //            .ForMember(destination => destination.ContractReferenceNumber, opt => opt.MapFrom(src => src.ID.Value))
        //            .ForMember(destination => destination.TotalAmount, opt => opt.MapFrom(src => src.LegalMonetaryTotal.TaxExclusiveAmount.Value))
        //            .ForMember(destination => destination.TotalTransactionAmount, opt => opt.MapFrom(src => src.LegalMonetaryTotal.TaxInclusiveAmount.Value))
        //            .ForMember(destination => destination.TotalGlobalDiscountAmount, opt => opt.MapFrom(src => src.LegalMonetaryTotal.AllowanceTotalAmount.Value))
        //            .ForPath(destination => destination.Party, opt => opt.MapFrom(src => MapParty(src.AccountingCustomerParty.Party, src.Delivery.Cast<DeliveryType>().FirstOrDefault().DeliveryLocation)))
        //            .ForPath(destination => destination.CustomerParty, opt => opt.MapFrom(src => MapParty(src.AccountingCustomerParty.Party, src.Delivery.Cast<DeliveryType>().FirstOrDefault().DeliveryLocation)))
        //            .ForPath(destination => destination.SupplierParty, opt => opt.MapFrom(src => MapParty(src.AccountingSupplierParty.Party, src.Delivery.Cast<DeliveryType>().FirstOrDefault().DeliveryLocation)))
        //            .ForPath(destination => destination.UnloadPlaceAddress, opt => opt.MapFrom(src => MapUnloadPlaceAddress(src.Delivery.Cast<DeliveryType>().FirstOrDefault().DeliveryLocation.Address)))
        //            .ForPath(destination => destination.Details, opt => opt.MapFrom(src => MapCreditNoteLines(src.CreditNoteLine)))
        //            .ForAllOtherMembers(opt => opt.Ignore()); // Ignore all other members, including methods
        //    });
        //}

        /// <summary>
        /// Maps a PartyType object to a Party object.
        /// </summary>
        /// <param name="partyType"></param>
        /// <returns></returns>
        //private Models.Party MapParty(Models.Saphety.Party partyType, LocationType locationType)
        private Models.Party MapParty(Models.Saphety.Party partyType)
        {
            var organizationName = partyType.Name;

            return new Models.Party
            {
                // Map properties from PartyType to Party here
                FederalTaxID = partyType.VatNumber,
                OrganizationName = organizationName,
                AddressLine1 = partyType.Address,
                //AddressLine2 = partyType.PostalAddress?.AdditionalStreetName?.Value,
                PostalCode = partyType.ZipCode,
                CountryID = partyType.Country,
                //GLN = locationType.ID?.Value
            };
        }

        /// <summary>
        /// Maps an AddressType object to an UnloadPlaceAddress object.
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        private UnloadPlaceAddress MapUnloadPlaceAddress(Models.Saphety.Party address)
        {
            return new UnloadPlaceAddress
            {
                AddressLine1 = address?.Address,
                //AddressLine2 = address?.AdditionalStreetName?.Value,
                PostalCode = address.ZipCode,
                CountryID = address.Country,
            };
        }

        /// <summary>
        /// Maps a collection of InvoiceLineType objects to a collection of Detail objects.
        /// </summary>
        /// <param name="invoiceLines"></param>
        /// <returns></returns>
        private List<Detail> MapInvoiceLines(IEnumerable<LineItem> invoiceLines)
        {
            var details = new List<Detail>();

            foreach (var line in invoiceLines)
            {
                var description = line?.ItemDescription;

                var detail = new Detail
                {
                    // Map properties from InvoiceLineType to Detail here
                    Quantity = (int?)line?.Quantity?.Value,
                    UnitPrice = (double)line?.NetPrice,
                    TotalNetAmount = (double)line?.NetLineAmount,
                    ItemID = line?.TradeItemIdentification,
                    Description = description,
                    TaxList = new List<TaxList>
                    {
                        new TaxList
                        {
                            TaxRate = (double?)(line?.LineVat?.TaxPercentage),
                            //TaxCode = line?.Item?.ClassifiedTaxCategory?.FirstOrDefault()?.ID?.Value,
                        }
                    },
                    //DetailNotes = line?.Note?.Select(n => n.Value).ToList()
                };

                

                //if (line?.AllowanceCharge?.FirstOrDefault()?.MultiplierFactorNumeric.Value != null)
                //    detail.DiscountPercent = (double)line?.AllowanceCharge?.FirstOrDefault()?.MultiplierFactorNumeric.Value;

                details.Add(detail);
            }

            return details;
        }

        ///// <summary>
        ///// Maps a collection of CreditNoteLineType objects to a collection of Detail objects.
        ///// </summary>
        ///// <param name="creditNoteLines"></param>
        ///// <returns></returns>
        //private List<Detail> MapCreditNoteLines(IEnumerable<CreditNoteLineType> creditNoteLines)
        //{
        //    var details = new List<Detail>();

        //    foreach (var line in creditNoteLines)
        //    {
        //        var description = line?.Item?.Description?.FirstOrDefault()?.Value ?? line?.Item?.Name?.Value;

        //        var detail = new Detail
        //        {
        //            // Map properties from InvoiceLineType to Detail here
        //            Quantity = (int?)line?.CreditedQuantity?.Value,
        //            UnitPrice = (double)line?.Price?.PriceAmount?.Value,
        //            TotalNetAmount = (double)line?.LineExtensionAmount?.Value,
        //            ItemID = line?.Item.SellersItemIdentification?.ID?.Value ?? line?.Item.BuyersItemIdentification?.ID?.Value,
        //            Description = description,
        //            TaxList = new List<TaxList>
        //            {
        //                new TaxList
        //                {
        //                    TaxRate = (double?)(line?.Item?.ClassifiedTaxCategory?.FirstOrDefault()?.Percent?.Value),
        //                    TaxCode = line?.Item?.ClassifiedTaxCategory?.FirstOrDefault()?.ID?.Value,
        //                }
        //            },
        //            DetailNotes = line?.Note?.Select(n => n.Value).ToList()
        //        };

        //        if (line?.AllowanceCharge?.FirstOrDefault()?.MultiplierFactorNumeric.Value != null)
        //            detail.DiscountPercent = (double)line?.AllowanceCharge?.FirstOrDefault()?.MultiplierFactorNumeric.Value;

        //        details.Add(detail);
        //    }

        //    return details;
        //}

        #endregion
    }
}