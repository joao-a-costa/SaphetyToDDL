using Newtonsoft.Json;

namespace SaphetyToDDL.Lib.Models
{
    /// <summary>
    /// Represents a payment.
    /// </summary>
    public class Payment
    {
        [JsonProperty("PaymentID")]
        public double? PaymentID;

        [JsonProperty("PaymentKey")]
        public string PaymentKey;

        [JsonProperty("Description")]
        public string Description;

        [JsonProperty("PaymentDays")]
        public double? PaymentDays;

        [JsonProperty("PaymentDaysAfter")]
        public double? PaymentDaysAfter;

        [JsonProperty("IssueReceipt")]
        public bool? IssueReceipt;

        [JsonProperty("InternalUse")]
        public bool? InternalUse;

        [JsonProperty("ExtendedProperties")]
        public System.Collections.Generic.List<object> ExtendedProperties;

        [JsonProperty("InstallmentList")]
        public System.Collections.Generic.List<object> InstallmentList;

        [JsonProperty("PaymentDateType")]
        public double? PaymentDateType;

        [JsonProperty("Installments")]
        public double? Installments;

        [JsonProperty("InstallmentsType")]
        public double? InstallmentsType;

        [JsonProperty("TenderID")]
        public double? TenderID;
    }


}
