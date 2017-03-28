using System;
using Newtonsoft.Json;

namespace Trak.Client.Portable
{
	public class RouteItem
	{
		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("departDT")]
		public string DepartDT { get; set; }

		[JsonProperty("arriveDT")]
		public string ArriveDT { get; set; }

		[JsonProperty("status")]
		public int Status { get; set; }

		[JsonProperty("point")]
		public int Point { get; set; }

		[JsonProperty("blockchain")]
		public int BlockChain { get; set; }

		public RouteItem(string title)
		{
			Title = title;
		}
	}
}
