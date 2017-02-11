using System;

namespace Qlick.Client.Portable
{
	public class TaskItem
	{
		public string Title { get; private set;}

		public string Description { get; private set; }

		public string AppId { get; private set; }

		public TaskItem(string title, string description , string appId)
		{
			Title = title;
			Description = description;
			AppId = appId;
		}
	}
}
