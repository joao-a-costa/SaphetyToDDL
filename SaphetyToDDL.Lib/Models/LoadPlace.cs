using Newtonsoft.Json;

namespace SaphetyToDDL.Lib.Models
{
    /// <summary>
    /// Represents a load place.
    /// </summary>
    public class LoadPlace
    {
        [JsonProperty("LoadUnloadPlaceID")]
        public double? LoadUnloadPlaceID;

        [JsonProperty("Description")]
        public string Description;

        [JsonProperty("AddressType")]
        public double? AddressType;

        [JsonProperty("AddressTypeID")]
        public double? AddressTypeID;

        [JsonProperty("ExtendedProperties")]
        public System.Collections.Generic.List<object> ExtendedProperties;
    }
}
