using System;

namespace Qlick.Client.Portable
{
	public class TaskItem
	{
		public string Title { get; }

		public string Description { get; }

		public string AppId { get; }

		public TaskItem(string title, string description , string appId)
		{
			Title = title;
			Description = description;
			AppId = appId;
		}

	}
}
