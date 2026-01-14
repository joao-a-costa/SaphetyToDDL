using System.Xml.Serialization;
using System.Globalization;

namespace SaphetyToDDL.Lib.Models.Saphety
{
    public class LineVat
    {
        [XmlIgnore]
        public decimal TaxPercentage { get; set; }

        [XmlElement("taxPercentage")]
        public string TaxPercentageString
        {
            get => TaxPercentage.ToString("F2", CultureInfo.InvariantCulture);
            set => TaxPercentage = decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var v) ? v : 0;
        }

        [XmlIgnore]
        public decimal TaxTotalValue { get; set; }

        [XmlElement("taxTotalValue")]
        public string TaxTotalValueString
        {
            get => TaxTotalValue.ToString("F2", CultureInfo.InvariantCulture);
            set => TaxTotalValue = decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var v) ? v : 0;
        }

        [XmlIgnore]
        public decimal TaxableAmount { get; set; }

        [XmlElement("taxableAmount")]
        public string TaxableAmountString
        {
            get => TaxableAmount.ToString("F2", CultureInfo.InvariantCulture);
            set => TaxableAmount = decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var v) ? v : 0;
        }
    }
}
