using System;
using System.Collections.Generic;

namespace Trak.Client.Portable
{
	public static class MockFactory
	{
		public static List<TaskItem> GenerateMockTasks()
		{
			List<TaskItem> tasks = new List<TaskItem>();
			for (int c = 0; c < 500; c++)
			{
				tasks.Add(new TaskItem("guiid",
				                       "Update database structure for new module (prod) " + c, 
				                       "New datetime field has been added to keep track of the datetime whenever records are updated." + c, 
				                       randAppId(),
									   "tanjavan",
				                       randDT(),
				                       randDT(true),
				                       randPriority(),
				                       "Details"
				));
			}

			return tasks;
		}

		static string[] apps = new string[] {
			"prism", "rekiweb", "leave", "daw"
		};

		static Random rand = new Random();

		static string randAppId()
		{
			return apps[rand.Next(0, apps.Length)];
		}

		static DateTime randDT(bool past = false)
		{
			int m = past ? -1 : 1;
			return DateTime.Now.AddDays(m * rand.Next(0, 10))
					.AddHours(m * rand.Next(0, 24))
					.AddMinutes(m * rand.Next(0, 60))
						   .AddSeconds(m * rand.Next(0, 60));
		}

		static Priority randPriority()
		{
			return (Priority)rand.Next(0, 2);
		}
	}
}
