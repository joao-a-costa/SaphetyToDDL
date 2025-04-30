using System.Xml.Serialization;

namespace SaphetyToDDL.Lib.Models.Saphety
{
    public class Quantity
    {
        [XmlElement("value")]
        public decimal Value { get; set; }

        [XmlElement("unitCodeValue")]
        public string UnitCodeValue { get; set; } = "UN";
    }
}
