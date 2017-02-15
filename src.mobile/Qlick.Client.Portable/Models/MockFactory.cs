using System;
using System.Collections.Generic;

namespace Qlick.Client.Portable
{
	public static class MockFactory
	{
		public static List<TaskItem> GenerateMockTasks()
		{
			List<TaskItem> tasks = new List<TaskItem>();
			for (int c = 0; c < 500; c++)
			{
				tasks.Add(new TaskItem("Update database structure for new module (prod) " + c, 
				                       "New datetime field has been added to keep track of the datetime whenever records are updated." + c, 
				                       randAppId(),
									   "tanjavan"
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
	}
}
