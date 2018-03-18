using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using api.Models.Definitions;

namespace api.Models
{
    public class Nuance
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [JsonProperty("nuance_id")]
        public int NuanceID { get; set; }

        [Required]
        [JsonProperty("title")]
        public string Title { get; set; }

        [Required]
        [JsonProperty("descr")]
        public string Description { get; set; }

        [Required]
        [JsonProperty("shipper_name")]
        public string ShipperName { get; set; }

        [Required]
        [JsonProperty("created_dt")]
        public DateTime CreatedDT { get; set; }

        [Required]
        [JsonProperty("due_dt")]
        public DateTime DueDT { get; set; }

        [Required]
        [JsonProperty("priority")]
        public Priority Priority { get; set; }

        [Required]
        [JsonProperty("details")]
        public string Details { get; set; }


        [JsonProperty("jo_size")]
        public int JoSize
        {
            get
            {
                return Waypoints?.Count ?? 0;
            }
        }

        [JsonProperty("jo_index")]
        public int JoIndex
        {
            get
            {
                if (Waypoints == null) return 0;

                int c = 0;
                foreach (Waypoint wp in Waypoints)
                {
                    c += wp.Status < 0 ? 1 : 0;
                }

                return c;
            }

        }

        [JsonProperty("waypoints")]
        public IList<Waypoint> Waypoints { get; set; }

    }

}
