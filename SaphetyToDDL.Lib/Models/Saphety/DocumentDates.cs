using System;
using System.Xml.Serialization;

namespace SaphetyToDDL.Lib.Models.Saphety
{
    public class DocumentDates
    {
        [XmlElement("documentDate", DataType = "date")]
        public DateTime DocumentDate { get; set; }

        [XmlElement("dueDate", DataType = "date")]
        public DateTime DueDate { get; set; }
    }
}
