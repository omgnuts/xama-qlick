using System;
using Newtonsoft.Json;

namespace Trak.Client.Portable
{
	public class TaskItem
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("tptId")]
		public string UserId { get; set; }

		[JsonProperty("createdDt")]
		public DateTime CreatedDT { get; set; }

		[JsonProperty("systId")]
		public string SystId { get; set; }

		[JsonProperty("dueDt")]
		public DateTime DueDT { get; set; }

		[JsonProperty("priority")]
		public Priority Priority { get; set; } 

		[JsonProperty("details")]
		public string Details { get; set; } 

		[JsonProperty("joSize")]
		public int JoSize { get; set; }

		[JsonProperty("joIndex")]
		public int JoIndex { get; set; }

		//public TaskItem(string id, string title, string description, string systId, string userId,
		//                DateTime createdDT, DateTime dueDT, Priority priority, string details, 
		//                int joSize, int joIndex)
		//{
		//	Id = id; 
		//	Title = title;
		//	Description = description;
		//	SystId = systId;
		//	UserId = userId;
		//	CreatedDT = createdDT.AddHours(-8);
		//	DueDT = dueDT;
		//	Priority = priority;
		//	Details = details;

		//	JoSize = joSize;
		//	JoIndex = joIndex;
		//}

		
	}
}
