﻿using System.Xml.Serialization;

namespace SaphetyToDDL.Lib.Models.Saphety
{
    public class LineVat
    {
        [XmlElement("taxPercentage")]
        public decimal TaxPercentage { get; set; }

        [XmlElement("taxTotalValue")]
        public decimal TaxTotalValue { get; set; }
    }
}
