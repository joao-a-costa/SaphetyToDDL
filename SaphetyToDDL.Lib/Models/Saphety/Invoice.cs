using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SaphetyToDDL.Lib.Models.Saphety
{
    [XmlRoot("invoice")]
    public class Invoice
    {
        [XmlAttribute("docInstanceId")]
        public string DocInstanceId { get; set; } = Guid.NewGuid().ToString();

        [XmlAttribute("documentCorrelationId")]
        public string DocumentCorrelationId { get; set; } = Guid.NewGuid().ToString();

        [XmlAttribute("docTypeId")]
        public string DocTypeId { get; set; } = "1";

        [XmlElement("senderSoftwareCertificationNumber")]
        public string SenderSoftwareCertificationNumber { get; set; } = "XXXX";

        [XmlElement("senderSoftwareDocumentSignatureHash")]
        public string SenderSoftwareDocumentSignatureHash { get; set; } = "XXXX";

        [XmlElement("currencyISOCode")]
        public string CurrencyISOCode { get; set; } = "EUR";

        [XmlElement("documentNumber")]
        public string DocumentNumber { get; set; }

        [XmlElement("documentDates")]
        public DocumentDates DocumentDates { get; set; }

        [XmlElement("binaryDocumentFormat")]
        public BinaryDocumentFormat BinaryDocumentFormat { get; set; }

        [XmlElement("partyInformation")]
        public PartyInformation PartyInformation { get; set; }

        [XmlElement("documentReferences")]
        public DocumentReferences DocumentReferences { get; set; }

        [XmlElement("paymentTerms")]
        public PaymentTerms PaymentTerms { get; set; }

        [XmlElement("lineItem")]
        public List<LineItem> LineItems { get; set; }

        [XmlElement("documentTotals")]
        public DocumentTotals DocumentTotals { get; set; }

        [XmlElement("metaInfo")]
        public MetaInfo MetaInfo { get; set; }

        [XmlElement("paymentMethod")]
        public PaymentMethod PaymentMethod { get; set; } = new PaymentMethod();
    }
}
