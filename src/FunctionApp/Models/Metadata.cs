using Newtonsoft.Json;
using System;

namespace ECMA.APP.Models
{
    public class Metadata
    {
        [JsonProperty("MESSAGE_RECEIVED")]
        public DateTime MessageReceived { get; set; }
        [JsonProperty("VERSION")]
        public string Version { get; set; }
    }
}
