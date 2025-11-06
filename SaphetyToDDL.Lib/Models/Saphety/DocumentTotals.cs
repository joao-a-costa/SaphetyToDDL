using System.Collections.Generic;
using System.Xml.Serialization;

namespace SaphetyToDDL.Lib.Models.Saphety
{
    public class DocumentTotals
    {
        [XmlElement("totalAmountPayable")]
        public decimal TotalAmountPayable { get; set; }

        [XmlElement("totalVatAmount")]
        public decimal TotalVatAmount { get; set; }

        [XmlElement("totalVatTaxableAmount")]
        public decimal TotalVatTaxableAmount { get; set; }

        [XmlElement("totalNetAmount")]
        public decimal TotalNetAmount { get; set; }

        [XmlElement("vatSummary")]
        public List<VatSummary> VatSummary { get; set; }
    }
}
