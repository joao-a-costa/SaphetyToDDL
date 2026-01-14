using System.Xml.Serialization;
using System.Globalization;

namespace SaphetyToDDL.Lib.Models.Saphety
{
    public class Quantity
    {
        [XmlIgnore]
        public decimal Value { get; set; }

        [XmlElement("value")]
        public string ValueString
        {
            get => Value.ToString("F2", CultureInfo.InvariantCulture);
            set => Value = decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var v) ? v : 0;
        }

        [XmlElement("unitCodeValue")]
        public string UnitCodeValue { get; set; } = "UN";
    }
}
