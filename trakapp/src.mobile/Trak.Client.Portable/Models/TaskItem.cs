using System;
using Newtonsoft.Json;

namespace Trak.Client.Portable
{
	public class TaskItem
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("tptId")]
		public string UserId { get; set; }

		[JsonProperty("createdDt")]
		public DateTime CreatedDT { get; set; }

		[JsonProperty("systId")]
		public string SystId { get; set; }

		[JsonProperty("dueDt")]
		public DateTime DueDT { get; set; }

		[JsonProperty("priority")]
		public Priority Priority { get; set; } 

		[JsonProperty("details")]
		public string Details { get; set; } 

		[JsonProperty("joSize")]
		public int JoSize { get; set; }

		[JsonProperty("joIndex")]
		public int JoIndex { get; set; }

		[JsonProperty("routeItems")]
		public RouteItem[] RouteItems { get; set; }

		
	}
}
