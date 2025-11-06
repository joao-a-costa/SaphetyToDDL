using Newtonsoft.Json;

namespace SaphetyToDDL.Lib.Models
{
    public class TaxValue
    {
        [JsonProperty("TaxRate")]
        public double TaxRate { get; set; }
        [JsonProperty("TotalIncidenceAmount")]
        public double TotalIncidenceAmount { get; set; }
        [JsonProperty("TotalNetChargeableAmount")]
        public double TotalNetChargeableAmount { get; set; }
        [JsonProperty("TotalTaxAmount")]
        public double TotalTaxAmount { get; set; }
        [JsonProperty("TaxGroupId")]
        public string TaxGroupId { get; set; }
        [JsonProperty("TaxCode")]
        public string TaxCode { get; set; }
        [JsonProperty("TotalAmount")]
        public double TotalAmount { get; set; }
    }
}
