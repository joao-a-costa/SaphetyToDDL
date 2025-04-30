using Newtonsoft.Json;

namespace SaphetyToDDL.Lib.Models
{
    /// <summary>
    /// Represents a sale price.
    /// </summary>
    public class SalePrice
    {
        [JsonProperty("LotID")]
        public object LotID;

        [JsonProperty("PriceLineID")]
        public double? PriceLineID;

        [JsonProperty("SizeID")]
        public double? SizeID;

        [JsonProperty("ColorID")]
        public double? ColorID;

        [JsonProperty("UnitOfMeasureID")]
        public object UnitOfMeasureID;

        [JsonProperty("PropertyValue1")]
        public object PropertyValue1;

        [JsonProperty("PropertyValue2")]
        public object PropertyValue2;

        [JsonProperty("PropertyValue3")]
        public object PropertyValue3;

        [JsonProperty("UnitPrice")]
        public double? UnitPrice;

        [JsonProperty("TaxIncludedPrice")]
        public double? TaxIncludedPrice;

        [JsonProperty("CreateDate")]
        public System.DateTime? CreateDate;

        [JsonProperty("CurrencyID")]
        public string CurrencyID;

        [JsonProperty("CurrencyFactor")]
        public double? CurrencyFactor;

        [JsonProperty("CurrencyExchange")]
        public double? CurrencyExchange;

        [JsonProperty("FixedProfitRate")]
        public double? FixedProfitRate;

        [JsonProperty("ExcludesGlobalDiscount")]
        public bool? ExcludesGlobalDiscount;

        [JsonProperty("DiscountPercent")]
        public double? DiscountPercent;

        [JsonProperty("PriceUnitID")]
        public object PriceUnitID;
    }


}
