using System.Xml.Serialization;

namespace SaphetyToDDL.Lib.Models.Saphety
{
    public class PartyInformation
    {
        [XmlElement("seller")]
        public Party Seller { get; set; }

        [XmlElement("buyer")]
        public Party Buyer { get; set; }

        [XmlElement("shipTo")]
        public Party ShipTo { get; set; }
    }
}
