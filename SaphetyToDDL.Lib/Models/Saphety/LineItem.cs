using System.Xml.Serialization;
using System.Globalization;

namespace SaphetyToDDL.Lib.Models.Saphety
{
    public class LineItem
    {
        [XmlAttribute("number")]
        public int Number { get; set; }

        [XmlElement("tradeItemIdentification")]
        public string TradeItemIdentification { get; set; }

        [XmlIgnore]
        public decimal NetPrice { get; set; }

        [XmlElement("netPrice")]
        public string NetPriceString
        {
            get => NetPrice.ToString("F2", CultureInfo.InvariantCulture);
            set => NetPrice = decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var v) ? v : 0;
        }

        [XmlElement("itemDescription")]
        public string ItemDescription { get; set; }

        [XmlIgnore]
        public decimal NetLineAmount { get; set; }

        [XmlElement("netLineAmount")]
        public string NetLineAmountString
        {
            get => NetLineAmount.ToString("F2", CultureInfo.InvariantCulture);
            set => NetLineAmount = decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var v) ? v : 0;
        }

        [XmlElement("quantity")]
        public Quantity Quantity { get; set; }

        [XmlElement("lineVat")]
        public LineVat LineVat { get; set; }
    }
}
