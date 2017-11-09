using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace ModulbankClient
{
    public class OperationCondition
    {
        [JsonProperty("category")]
        [JsonConverter(typeof(StringEnumConverter))]
        public OperationCategory? Category { get; set; }

        [JsonProperty("from")]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime? From { get; set; }

        [JsonProperty("till")]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime? Till { get; set; }

        [JsonProperty("skip")]
        public int? Skip { get; set; }

        [JsonProperty("records")]
        public int? Records { get; set; }
    }
}
