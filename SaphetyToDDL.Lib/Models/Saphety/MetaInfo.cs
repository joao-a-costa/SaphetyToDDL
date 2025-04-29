using System.Xml.Serialization;

namespace SaphetyToDDL.Lib.Models.Saphety
{
    public class MetaInfo
    {
        [XmlElement("key")]
        public string Key { get; set; }

        [XmlElement("value")]
        public string Value { get; set; }
    }
}
