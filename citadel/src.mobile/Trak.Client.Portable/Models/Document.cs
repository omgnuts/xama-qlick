using System;
using Newtonsoft.Json;

namespace Trak.Client.Portable.Models
{
    public class Document
    {
        [JsonProperty("FileId")]
        public string FileId { get; set; }
        //"FileId": "d294384f-c6fa-40c5-9192-fd99598ad92f",
    
        [JsonProperty("FileType")]
        public string FileType { get; set; }
        //"FileType": "bitmap",

        [JsonProperty("FileHash")]
        public string FileHash { get; set; }
        //"FileHash": "b614d7274d793bb90df36131e2853a85e0a1fbf6dda56cc8b1bc4c3d369cd1aa",

        [JsonProperty("DocumentName")]
        public string DocumentName { get; set; }
        //"DocumentName": "Bill of Lading - 2nd Tier Shipping Line.jpg",

        [JsonProperty("UploadedBy")]
        public string UploaderId { get; set; }
        //"UploadedBy": "yeosk@1citadel.com",

        [JsonProperty("UploadedOn")]
        public DateTime UploadedDT { get; set; }
        // "UploadedOn": "2018-04-04T11:38:28.0140511Z",

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
        public int StageItemId { get; set; }
        //"StageItemNumber": 1,

        [JsonIgnore]
        public string RequestKey {
            get
            {
                return $"{StageId}-{StageItemId}";
            }
        }
    }
}

