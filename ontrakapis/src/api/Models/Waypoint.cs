using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using api.Models.Definitions;

namespace api.Models
{
    public class Waypoint
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [JsonProperty("waypoint_id")]
        public int WaypointID { get; set; }

        [Required]
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("depart_dt")]
        public DateTime? DepartDT { get; set; }

        [JsonProperty("arrive_dt")] 
        public DateTime? ArriveDT { get; set; }

        [Required]
        [JsonProperty("order")]
        public int Order { get; set; }

        [Required]
        [JsonProperty("status")]
        public WaypointStatus Status { get; set; }

        [Required]
        [JsonProperty("path")]
        public WaypointPath Path { get; set; }

        [Required]
        [JsonProperty("documents")]
        public IList<Document> Documents { get; set; }
        
    }
}
