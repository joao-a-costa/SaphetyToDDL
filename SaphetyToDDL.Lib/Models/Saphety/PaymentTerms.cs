using System.Xml.Serialization;

namespace SaphetyToDDL.Lib.Models.Saphety
{
    public class PaymentTerms
    {
        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("value")]
        public string Value { get; set; } = "PP";
    }
}
