using System;
namespace Qlick.Client.Portable
{
	public class SearchItem
	{
		public string Title { get; }

		public string Description { get; }

		public SearchItem(string title, string descr)
		{
			Title = title;
			Description = descr;
		}
	}
}
