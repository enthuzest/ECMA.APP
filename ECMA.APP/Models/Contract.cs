using Newtonsoft.Json;
using System;

namespace ECMA.APP.Models
{
    public class Contract
    {
        [JsonProperty("CONTRACT_ID")]
        public string ContractId { get; set; }
        [JsonProperty("CREATED_DATE")]
        public DateTime CreatedDate { get; set; }
        [JsonProperty("END_DATE")]
        public DateTime EndDate { get; set; }
        [JsonProperty("UPDATE_DATETIME")]
        public DateTime UpdateDatetime { get; set; }
        [JsonProperty("PRICE")]
        public decimal Price { get; set; }
        [JsonProperty("OWNER")]
        public string Owner { get; set; }
        [JsonProperty("METADATA")]
        public Metadata MetadataDetails { get; set; }
    }
}
