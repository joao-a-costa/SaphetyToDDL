using System.Xml.Serialization;

namespace SaphetyToDDL.Lib.Models.Saphety
{
    public class Party
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("country")]
        public string Country { get; set; }

        [XmlElement("vatNumber")]
        public string VatNumber { get; set; }

        [XmlElement("address")]
        public string Address { get; set; }

        [XmlElement("city")]
        public string City { get; set; }

        [XmlElement("zipCode")]
        public string ZipCode { get; set; }

        [XmlElement("zipArea")]
        public string ZipArea { get; set; } = string.Empty;

        [XmlElement("gln")]
        public string Gln { get; set; } = string.Empty;
    }
}
