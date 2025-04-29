using System.Xml.Serialization;

namespace SaphetyToDDL.Lib.Models.Saphety
{
    public class VatSummary
    {
        [XmlElement("taxPercentage")]
        public decimal TaxPercentage { get; set; }

        [XmlElement("taxTotalValue")]
        public decimal TaxTotalValue { get; set; }

        [XmlElement("taxableAmount")]
        public decimal TaxableAmount { get; set; }
    }
}
