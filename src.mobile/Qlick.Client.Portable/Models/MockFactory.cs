using System;
using System.Collections.Generic;

namespace Qlick.Client.Portable
{
	public static class MockFactory
	{
		public static List<TaskItem> GenerateMockTasks()
		{
			List<TaskItem> tasks = new List<TaskItem>();
			for (int c = 0; c < 200; c++)
			{
				tasks.Add(new TaskItem("Title " + c, "Descr " + c, randAppId()));
			}

			return tasks;
		}

		static string[] apps = new string[] {
			"prism", "reki", "leave"
		};


		static Random rand = new Random();

		static string randAppId()
		{
			return apps[rand.Next(0, apps.Length)];
		}
	}
}
