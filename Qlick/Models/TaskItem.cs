using System;
namespace Qlick
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
