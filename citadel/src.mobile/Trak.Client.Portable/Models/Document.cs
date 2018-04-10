using System;
using Newtonsoft.Json;
using Trak.Client.Portable.Common;

namespace Trak.Client.Portable.Models
{
    public class Document
    {
        [JsonProperty("FileType")]
        public string FileType { get; set; }
        //"FileType": "bitmap",

        [JsonProperty("Filename")]
        public string Filename { get; set; }
        //"DocumentName": "Bill of Lading - 2nd Tier Shipping Line.jpg",

        [JsonProperty("FileHash")]
        public string FileHash { get; set; }
        //"FileHash": "b614d7274d793bb90df36131e2853a85e0a1fbf6dda56cc8b1bc4c3d369cd1aa",

        [JsonProperty("User")]
        public string User { get; set; }
        //"FileId": "yeosk@1citadel.com",

        [JsonProperty("FileUploaded")]
        public DateTime FileUploaded { get; set; }
        //"FileId": "0001-01-01T00:00:00",

        [JsonProperty("FileData")]
        [JsonConverter(typeof(JsonBase64Converter))]
        public byte[] FileData { get; set; }

        [JsonProperty("id")]
        public string TxnId { get; set; }
        //"id": "ab491359da0376249121bf3eb7437879c2273ba1c501be971e96d59b8681bc99",

        [JsonProperty("timestamp")]
        public DateTime? TxnDT { get; set; }
        //"timestamp": "2018-04-04T11:39:33+00:00",

        public string FilenameWithExtension {
            get {
                if (Filename == null) return null;
                string[] tokens = Filename.Split('\\');
                if (tokens.Length == 0) return null;
                return tokens[tokens.Length - 1];
            }
        }




    }
}

