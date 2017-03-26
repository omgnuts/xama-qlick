﻿using System;

namespace Trak.Client.Portable
{
	public class TaskItem
	{
		public string Id { get; }

		public string Title { get; }

		public string Description { get; }

		public string SystId { get; }

		public string UserId { get; }

		public DateTime CreatedDT { get; }

		public DateTime DueDT { get; }

		public Priority Priority { get; } 

		public string Details { get; } 

		public TaskItem(string id, string title, string description, string systId, string userId,
		                DateTime createdDT, DateTime dueDT, Priority priority, string details)
		{
			Id = id; 
			Title = title;
			Description = description;
			SystId = systId;
			UserId = userId;
			CreatedDT = createdDT.AddHours(-8);
			DueDT = dueDT;
			Priority = priority;
			Details = details;
		}

		
	}
}