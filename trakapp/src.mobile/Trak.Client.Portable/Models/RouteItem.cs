using System;
using Newtonsoft.Json;

namespace Trak.Client.Portable
{
	public class RouteItem
	{
		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("depart_dt")]
		public DateTime? DepartDT { get; set; }

		[JsonProperty("arrive_dt")]
		public DateTime? ArriveDT { get; set; }

		[JsonProperty("status")]
		public int Status { get; set; }

		[JsonProperty("path")]
		public int Point { get; set; }

		[JsonProperty("order")]
		public int Order { get; set; }

		[JsonProperty("blockchain")]
		public int BlockChain { get; set; }

		public RouteItem(string title)
		{
			Title = title;
		}
	}
}
