using System;
using Newtonsoft.Json;

namespace Trak.Client.Portable
{
	public class RouteItem
	{
		[JsonProperty("waypoint_id")]
		public int Id { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("depart_dt")]
		public DateTime? DepartDT { get; set; }

		[JsonProperty("arrive_dt")]
		public DateTime? ArriveDT { get; set; }

		[JsonProperty("status")]
		public WaypointStatus Status { get; set; }

		[JsonProperty("path")]
		public WaypointPath Point { get; set; }

		[JsonProperty("order")]
		public int Order { get; set; }

		[JsonProperty("documents")]
		public BlockDocument[] Documents { get; set; }

		public RouteItem(string title)
		{
			Title = title;
		}

	}
}
