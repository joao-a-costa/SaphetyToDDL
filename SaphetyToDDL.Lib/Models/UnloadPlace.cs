using Newtonsoft.Json;

namespace SaphetyToDDL.Lib.Models
{
    /// <summary>
    /// Represents an unload place.
    /// </summary>
    public class UnloadPlace
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
