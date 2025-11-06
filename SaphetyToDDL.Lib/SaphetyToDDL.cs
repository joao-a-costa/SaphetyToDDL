using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml.Serialization;
using AutoMapper;
using Newtonsoft.Json;
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
            Order = 2,
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

            string rootName = root.Name.LocalName;
            XAttribute attr = root.Attribute("docTypeId");
            string docTypeId = attr?.Value;
            if (!Enum.TryParse(docTypeId, out DocumentType documentType))
                throw new InvalidOperationException(_infoUnrecognizedDocumentType);

            var rootAttr = new XmlRootAttribute(rootName);
            var serializer = new XmlSerializer(typeof(Invoice), rootAttr);
            Invoice document;
            using (var reader = new StringReader(fileContent))
            {
                document = (Invoice)serializer.Deserialize(reader);
            }

            ItemTransactionSaphetyDocumentType = documentType;

            config = MapConfig();

            var itemTransaction = config.CreateMapper().Map<ItemTransaction>(document);

            ItemTransactionSaphety = document;
            ItemTransaction = itemTransaction;

            return itemTransaction;
        }

        /// <summary>
        /// Maps an ItemTransaction object to an InvoiceType object.
        /// </summary>
        /// <param name="itemTransaction">The ItemTransaction object to map.</param>
        /// <returns>The mapped InvoiceType object.</returns>
        public static Invoice MapFromDdl(ItemTransaction itemTransaction)
        {
            var config = MapConfig();
            return config.CreateMapper().Map<Invoice>(itemTransaction);
        }

        public static Invoice MapFromDdlString(string itemTransactionString)
        {
            return MapFromDdl(JsonConvert.DeserializeObject<ItemTransaction>(itemTransactionString));
        }

        /// <summary>
        /// Serializes an Invoice object to XML format.
        /// </summary>
        /// <param name="invoice">The Invoice object to serialize.</param>
        /// <returns>The serialized XML string.</returns>
        public static string SerializeInvoiceToXml(Invoice invoice)
        {
            var serializer = new XmlSerializer(typeof(Invoice));
            using (var stringWriter = new StringWriter())
            {
                serializer.Serialize(stringWriter, invoice);
                return stringWriter.ToString();
            }
        }

        #endregion

        #region "Private"

        /// <summary>
        /// Maps an InvoiceType object to an ItemTransaction object.
        /// </summary>
        /// <returns>The mapper configuration</returns>
        private static MapperConfiguration MapConfig()
        {
            return new MapperConfiguration(cfg =>
            {
                // Mapping: Invoice ➔ ItemTransaction
                cfg.CreateMap<Invoice, ItemTransaction>()
                    .ForMember(destination => destination.Base64, opt => opt.MapFrom(src => src.BinaryDocumentFormat.ContentData))
                    .ForMember(destination => destination.CreateDate, opt => opt.MapFrom(src => src.DocumentDates.DocumentDate))
                    .ForMember(destination => destination.DeferredPaymentDate, opt => opt.MapFrom(src => src.DocumentDates.DueDate))
                    .ForMember(destination => destination.ContractReferenceNumber, opt => opt.MapFrom(src => src.DocumentReferences.OrderReference))
                    .ForMember(destination => destination.TotalAmount, opt => opt.MapFrom(src => src.DocumentTotals.TotalNetAmount))
                    .ForMember(destination => destination.TotalTransactionAmount, opt => opt.MapFrom(src => src.DocumentTotals.TotalAmountPayable))
                    .ForMember(destination => destination.TotalTaxAmount, opt => opt.MapFrom(src => src.DocumentTotals.TotalVatAmount))
                    .ForMember(destination => destination.ISignableTransactionTransactionID, opt => opt.MapFrom(src => src.DocumentNumber))
                    //.ForPath(destination => destination.Payment.PaymentDays, opt => opt.MapFrom(src => $"{Regex.Replace(src.PaymentTerms.Value, "[a-zA-Z]", "")}"))
                    .ForPath(destination => destination.Payment.Description, opt => opt.MapFrom(src => src.PaymentTerms.Description))
                    .ForPath(destination => destination.Party, opt => opt.MapFrom(src => MapParty(src.PartyInformation.Buyer)))
                    //.ForPath(destination => destination.CustomerParty, opt => opt.MapFrom(src => MapParty(src.PartyInformation.Buyer)))
                    .ForPath(destination => destination.SupplierParty, opt => opt.MapFrom(src => MapParty(src.PartyInformation.Seller)))
                    .ForPath(destination => destination.UnloadPlaceAddress, opt => opt.MapFrom(src => MapUnloadPlaceAddress(src.PartyInformation.ShipTo)))
                    .ForPath(destination => destination.Details, opt => opt.MapFrom(src => MapInvoiceLines(src.LineItems)))
                    .ForPath(destination => destination.Taxes, opt => opt.MapFrom(src => MapTaxValues(src.DocumentTotals.VatSummary)))
                    //.ForPath(destination => destination.Taxes, opt => opt.MapFrom(src => MapTaxValues(src.tax.ShipTo)))
                    .ForAllOtherMembers(opt => opt.Ignore());

                // Mapping: ItemTransaction ➔ Invoice (Reverse mapping)
                cfg.CreateMap<ItemTransaction, Invoice>()
                    .ForPath(destination => destination.BinaryDocumentFormat.ContentData, opt => opt.MapFrom(src => src.Base64))
                    .ForPath(destination => destination.BinaryDocumentFormat.Name, opt => opt.MapFrom(src => src.ISignableTransactionTransactionID))
                    .ForPath(destination => destination.DocumentDates.DocumentDate, opt => opt.MapFrom(src => src.CreateDate))
                    .ForPath(destination => destination.DocumentDates.DueDate, opt => opt.MapFrom(src => src.DeferredPaymentDate))
                    .ForPath(destination => destination.DocumentReferences.OrderReference, opt => opt.MapFrom(src => src.ContractReferenceNumber))
                    .ForPath(destination => destination.DocumentTotals.TotalNetAmount, opt => opt.MapFrom(src => src.TotalAmount))
                    .ForPath(destination => destination.DocumentTotals.TotalAmountPayable, opt => opt.MapFrom(src => src.TotalTransactionAmount))
                    .ForPath(destination => destination.DocumentTotals.TotalVatAmount, opt => opt.MapFrom(src => src.TotalTaxAmount))
                    .ForPath(destination => destination.DocumentTotals.TotalVatTaxableAmount, opt => opt.MapFrom(src => src.TotalAmount))
                    .ForPath(destination => destination.DocumentNumber, opt => opt.MapFrom(src => src.ISignableTransactionTransactionID))
                    //.ForPath(destination => destination.PaymentTerms.Value, opt => opt.MapFrom(src => $"{src.Payment.PaymentDays}"))
                    .ForPath(destination => destination.PaymentTerms.Description, opt => opt.MapFrom(src => src.Payment.Description))
                    .ForPath(destination => destination.DocumentTotals.VatSummary, opt => opt.MapFrom(src => MapTaxValuesReverse(src.Taxes)))
                    .ForPath(destination => destination.PartyInformation.Buyer, opt => opt.MapFrom(src => MapPartyReverse(src.Party)))
                    .ForPath(destination => destination.PartyInformation.Seller, opt => opt.MapFrom(src => MapPartyReverse(src.SupplierParty == null ? src.Party : src.SupplierParty)))
                    .ForPath(destination => destination.PartyInformation.ShipTo, opt => opt.MapFrom(src => MapUnloadPlaceAddressReverse(src.UnloadPlaceAddress)))
                    .ForPath(destination => destination.LineItems, opt => opt.MapFrom(src => MapInvoiceLinesReverse(src.Details)))
                    .ForAllOtherMembers(opt => opt.Ignore());
            });
        }


        /// <summary>
        /// Maps a PartyType object to a Party object.
        /// </summary>
        /// <param name="party">The PartyType object to map.</param>
        /// <returns>The mapped Party object.</returns>
        private static Models.Party MapParty(Models.Saphety.Party party)
        {
            return new Models.Party
            {
                FederalTaxID = party.VatNumber,
                OrganizationName = party.Name,
                AddressLine1 = party.Address,
                PostalCode = party.ZipCode,
                CountryID = party.Country
            };
        }

        /// <summary>
        /// Maps a Party object to a PartyType object.
        /// </summary>
        /// <param name="party">The Party object to map.</param>
        /// <returns>The mapped PartyType object.</returns>
        private static Models.Saphety.Party MapPartyReverse(Models.Party party)
        {
            return new Models.Saphety.Party
            {
                VatNumber = party.FederalTaxID,
                Name = party.OrganizationName,
                Address = party.AddressLine1,
                ZipCode = party.PostalCode,
                Country = party.CountryID
            };
        }

        /// <summary>
        /// Maps an AddressType object to an UnloadPlaceAddress object.
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        private static UnloadPlaceAddress MapUnloadPlaceAddress(Models.Saphety.Party address)
        {
            return new UnloadPlaceAddress
            {
                AddressLine1 = address?.Address,
                PostalCode = address?.ZipCode,
                CountryID = address?.Country,
            };
        }

        /// <summary>
        /// Maps an UnloadPlaceAddress object to a PartyType object.
        /// </summary>
        /// <param name="address">The UnloadPlaceAddress object to map.</param>
        /// <returns>The mapped PartyType object.</returns>
        private static Models.Saphety.Party MapUnloadPlaceAddressReverse(UnloadPlaceAddress address)
        {
            return new Models.Saphety.Party
            {
                Address = address?.AddressLine1,
                ZipCode = address.PostalCode,
                Country = address.CountryID,
            };
        }

        /// <summary>
        /// Maps a collection of InvoiceLineType objects to a collection of Detail objects.
        /// </summary>
        /// <param name="invoiceLines"></param>
        /// <returns></returns>
        private static List<Detail> MapInvoiceLines(IEnumerable<LineItem> invoiceLines)
        {
            var details = new List<Detail>();

            foreach (var line in invoiceLines)
            {
                var description = line?.ItemDescription;

                var detail = new Detail
                {
                    // Map properties from InvoiceLineType to Detail here
                    Quantity = (double?)line?.Quantity?.Value,
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

                if (!detail.UnitPrice.HasValue || detail.UnitPrice == 0)
                {
                    if (detail.Quantity.HasValue && detail.Quantity != 0)
                    {
                        detail.UnitPrice = detail.TotalNetAmount / detail.Quantity;
                    }
                    else
                    {
                        // Handle the case where Quantity is 0 or null
                        detail.UnitPrice = 0; // Default value or alternative logic
                    }
                }

                //if (line?.AllowanceCharge?.FirstOrDefault()?.MultiplierFactorNumeric.Value != null)
                //    detail.DiscountPercent = (double)line?.AllowanceCharge?.FirstOrDefault()?.MultiplierFactorNumeric.Value;

                details.Add(detail);
            }

            return details;
        }

        /// <summary>
        /// Maps a collection of Detail objects to a collection of InvoiceLineType objects.
        /// </summary>
        /// <param name="invoiceLines">The collection of Detail objects to map.</param>
        /// <returns>The mapped collection of InvoiceLineType objects.</returns>
        private static List<LineItem> MapInvoiceLinesReverse(IEnumerable<Detail> invoiceLines)
        {
            int currentLineNumber = 1;
            var details = new List<LineItem>();
            foreach (var line in invoiceLines)
            {
                var detail = new LineItem
                {
                    // Map properties from InvoiceLineType to Detail here
                    Quantity = new Quantity
                    {
                        Value = (decimal)line.Quantity,
                    },
                    Number = currentLineNumber++,
                    NetPrice = (decimal)line.UnitPrice,
                    NetLineAmount = (decimal)line.TotalNetAmount,
                    TradeItemIdentification = line.ItemID,
                    ItemDescription = line.Description
                };

                var taxRate = line.TaxList.FirstOrDefault()?.TaxRate;

                if (line.TaxList.Any() && taxRate.HasValue)
                    detail.LineVat = new LineVat
                    {
                        TaxPercentage = (decimal)taxRate.Value,
                        TaxTotalValue = (decimal)(line.TotalTaxAmount.HasValue ? line.TotalTaxAmount.Value : 0),
                        TaxableAmount = (decimal)line.TotalNetAmount,
                    };


                details.Add(detail);
            }
            return details;
        }

        private static List<TaxValue> MapTaxValues(IEnumerable<Models.Saphety.VatSummary> vatSummaries)
        {
            var taxList = new List<TaxValue>();

            foreach (var vat in vatSummaries)
            {
                var tax = new TaxValue
                {
                    TaxRate = (double)vat.TaxPercentage,
                    TotalTaxAmount = (double)vat.TaxTotalValue,
                    TotalNetChargeableAmount = (double)vat.TaxableAmount
                };

                taxList.Add(tax);
            }

            return taxList;
        }

        private static List<Models.Saphety.VatSummary> MapTaxValuesReverse(IEnumerable<TaxValue> taxLists)
        {
            var taxValues = new List<Models.Saphety.VatSummary>();
            foreach (var tax in taxLists)
            {
                var taxValue = new Models.Saphety.VatSummary
                {
                    TaxPercentage = (decimal)tax.TaxRate,
                    TaxTotalValue = (decimal)(tax.TotalTaxAmount),
                    TaxableAmount = (decimal)(tax.TotalNetChargeableAmount),
                };
                taxValues.Add(taxValue);
            }
            return taxValues;
        }

        #endregion
    }
}