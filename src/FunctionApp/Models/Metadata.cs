using Newtonsoft.Json;
using System;

namespace ECMA.APP.Models
{
    public class Metadata
    {
        [JsonProperty("MESSAGERECEIVED")]
        public DateTime MessageReceived { get; set; }
        [JsonProperty("VERSION")]
        public string Version { get; set; }
    }
}
