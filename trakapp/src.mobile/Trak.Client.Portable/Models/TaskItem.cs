using System;
using Newtonsoft.Json;

namespace Trak.Client.Portable
{
	public class TaskItem
	{
		[JsonProperty("nuance_id")]
		public string Id { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("descr")]
		public string Description { get; set; }

		[JsonProperty("shipper_name")]
		public string UserId { get; set; }

		[JsonProperty("created_dt")]
		public DateTime CreatedDT { get; set; }

		[JsonProperty("due_dt")]
		public DateTime DueDT { get; set; }

		[JsonProperty("priority")]
		public Priority Priority { get; set; } 

		[JsonProperty("details")]
		public string Details { get; set; } 

		[JsonProperty("jo_size")]
		public int JoSize { get; set; }

		[JsonProperty("jo_index")]
		public int JoIndex { get; set; }

		[JsonProperty("waypoints")]
		public RouteItem[] RouteItems { get; set; }

		
	}
}
