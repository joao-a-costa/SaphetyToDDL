using System.Xml.Serialization;

namespace SaphetyToDDL.Lib.Models.Saphety
{
    public class LineItem
    {
        [XmlAttribute("number")]
        public int Number { get; set; }

        [XmlElement("tradeItemIdentification")]
        public string TradeItemIdentification { get; set; }

        [XmlElement("netPrice")]
        public decimal NetPrice { get; set; }

        [XmlElement("itemDescription")]
        public string ItemDescription { get; set; }

        [XmlElement("netLineAmount")]
        public decimal NetLineAmount { get; set; }

        [XmlElement("quantity")]
        public Quantity Quantity { get; set; }

        [XmlElement("lineVat")]
        public LineVat LineVat { get; set; }
    }
}
