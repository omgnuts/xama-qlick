using System;
using Newtonsoft.Json;

namespace Trak.Client.Portable.Models
{
    public class Shipment
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        // c46185221cf4c1679c736250a95503f1980df42ee3a3b70b3b7c32849165da37

        [JsonProperty("key")]
        public string Key { get; set; }
        // demo3

        [JsonProperty("TimelineId")]
        public string Title { get; set; }
        // demo3

        [JsonProperty("CreatedOn")]
        public DateTime CreatedDT { get; set; }
        // 2018-04-04T11:38:07.5647144Z

        [JsonProperty("CreatedBy")]
        public string CreatorId { get; set; }
        // "yeosk@1citadel.com"

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
        // 2018-04-04T11:38:14+00:00

        [JsonProperty("pending")]
        public bool Pending { get; set; }
        // false
    }
}
