using System;
using System.Xml.Serialization;

namespace SaphetyToDDL.Lib.Models.Saphety
{
    public class DocumentDates
    {
        [XmlElement("documentDate")]
        public DateTime DocumentDate { get; set; }

        [XmlElement("dueDate")]
        public DateTime DueDate { get; set; }
    }
}
