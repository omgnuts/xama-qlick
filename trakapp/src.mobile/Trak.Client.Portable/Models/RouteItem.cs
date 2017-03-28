using System;

namespace Trak.Client.Portable
{
	public class RouteItem
	{
		public string Title { get; set; }

		public string StartDT { get; set; }

		public string EndDT { get; set; }

		public int Status { get; set; }

		public int BlockChain { get; set; }

		public RouteItem(string title)
		{
			Title = title;
		}
	}
}
