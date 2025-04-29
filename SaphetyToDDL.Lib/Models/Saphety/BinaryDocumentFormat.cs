using System.Xml.Serialization;

namespace SaphetyToDDL.Lib.Models.Saphety
{
    public class BinaryDocumentFormat
    {
        [XmlElement("contentType")]
        public string ContentType { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }
    }
}
