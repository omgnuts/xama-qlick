using System;

namespace Qlick.Client.Portable
{
	public class TaskItem
	{
		public string Title { get; }

		public string Description { get; }

		public string SystId { get; }

		public string UserId { get; }

		public DateTime CreatedDT { get; }

		public DateTime DueDT { get; }

		public TaskItem(string title, string description, string systId, string userId)
		{
			Title = title;
			Description = description;
			SystId = systId;
			UserId = userId;
			CreatedDT = DateTime.Now.AddDays(-3);
			DueDT = DateTime.Now.AddDays(2);
		}
	}
}
