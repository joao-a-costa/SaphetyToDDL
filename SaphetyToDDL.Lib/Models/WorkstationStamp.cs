﻿using Newtonsoft.Json;

namespace SaphetyToDDL.Lib.Models
{
    /// <summary>
    /// Represents a workstation stamp.
    /// </summary>
    public class WorkstationStamp
    {
        [JsonProperty("WorkstationID")]
        public int? WorkstationID;

        [JsonProperty("SessionID")]
        public int? SessionID;

        [JsonProperty("UserId")]
        public int? UserId;

        [JsonProperty("UserGuid")]
        public string UserGuid;

        [JsonProperty("DateTimeStamp")]
        public System.DateTime? DateTimeStamp;
    }
}
