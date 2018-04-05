using System;
using Newtonsoft.Json;

namespace Trak.Client.Portable.Models
{
    public class StageItemTxn
    {
        [JsonProperty("id")]
        public string TxnId { get; set; }
        //"id": "ab491359da0376249121bf3eb7437879c2273ba1c501be971e96d59b8681bc99",

        [JsonProperty("timestamp")]
        public DateTime? TxnDT { get; set; }
        //"timestamp": "2018-04-04T11:39:33+00:00",

        [JsonProperty("StageNumber")]
        public int StageId { get; set; }
        //"StageNumber": 1,

        [JsonProperty("StageItemNumber")]
        public int SubStageId { get; set; }
        //"StageItemNumber": 1,
    }
}

