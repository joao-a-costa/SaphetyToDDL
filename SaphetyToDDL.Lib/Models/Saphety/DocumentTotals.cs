using System.Collections.Generic;
using System.Xml.Serialization;
using System.Globalization;

namespace SaphetyToDDL.Lib.Models.Saphety
{
    public class DocumentTotals
    {
        [XmlIgnore]
        public decimal TotalAmountPayable { get; set; }

        [XmlElement("totalAmountPayable")]
        public string TotalAmountPayableString
        {
            get => TotalAmountPayable.ToString("F2", CultureInfo.InvariantCulture);
            set => TotalAmountPayable = decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var v) ? v : 0;
        }

        [XmlIgnore]
        public decimal TotalVatAmount { get; set; }

        [XmlElement("totalVatAmount")]
        public string TotalVatAmountString
        {
            get => TotalVatAmount.ToString("F2", CultureInfo.InvariantCulture);
            set => TotalVatAmount = decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var v) ? v : 0;
        }

        [XmlIgnore]
        public decimal TotalVatTaxableAmount { get; set; }

        [XmlElement("totalVatTaxableAmount")]
        public string TotalVatTaxableAmountString
        {
            get => TotalVatTaxableAmount.ToString("F2", CultureInfo.InvariantCulture);
            set => TotalVatTaxableAmount = decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var v) ? v : 0;
        }

        [XmlIgnore]
        public decimal TotalNetAmount { get; set; }

        [XmlElement("totalNetAmount")]
        public string TotalNetAmountString
        {
            get => TotalNetAmount.ToString("F2", CultureInfo.InvariantCulture);
            set => TotalNetAmount = decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var v) ? v : 0;
        }

        [XmlElement("vatSummary")]
        public List<VatSummary> VatSummary { get; set; }
    }
}