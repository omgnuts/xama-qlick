using System;

namespace Qlick.Client.Portable
{
	public class TaskItem
	{
		public TaskItem Self { get; }

		public string Title { get; }

		public string Description { get; }

		public string AppId { get; }

		public TaskItem(string title, string description , string appId)
		{
			Self = this;
			
			Title = title;
			Description = description;
			AppId = appId;
		}

	}
}
