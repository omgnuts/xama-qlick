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

		public Priority Priority { get; } 

		public TaskItem(string title, string description, string systId, string userId,
		                DateTime createdDT, DateTime dueDT, Priority priority)
		{
			Title = title;
			Description = description;
			SystId = systId;
			UserId = userId;
			CreatedDT = createdDT;
			DueDT = dueDT;
			Priority = priority;
		}

		
	}
}
