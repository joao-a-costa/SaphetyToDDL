using System.Xml.Serialization;

namespace SaphetyToDDL.Lib.Models.Saphety
{
    public class PaymentMethod
    {
        [XmlElement("ibanCode")]
        public string IbanCode { get; set; } = string.Empty;

        [XmlElement("swiftCode")]
        public string SwiftCode { get; set; } = string.Empty;

        [XmlElement("bankName")]
        public string BankName { get; set; } = string.Empty;
    }
}
