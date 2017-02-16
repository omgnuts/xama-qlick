using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


namespace Qlick.Client.Portable
{
	public class QlickAPI
	{
		static QlickAPI instance;
		public static QlickAPI Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new QlickAPI();
				}
				return instance;
			}
		}

		static string Q_BASE = "http://go.munchpress.com";
		static string Q_ALLTASKS_GET = "qlick.json"; // api/tasks
		static string Q_USERTASKS_GET = "qlick.json"; // api/tasks/{userid}
		static string Q_USERTASKS_PENDING_GET = "qlick.json"; // api/tasks/{userid}/pending

		// Let this live for as long as the app needs to draw data.
		// TODO: handle it when user multi-tasks
		HttpClient client;

		QlickAPI()
		{
			client = new HttpClient();
			client.BaseAddress = new Uri(Q_BASE);
		}

        public async Task<List<TaskItem>> GetAllTasksAsync()
		{
			HttpResponseMessage resp = await client.GetAsync(Q_ALLTASKS_GET);

			if (resp.IsSuccessStatusCode)
			{
				var content = await resp.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<List<TaskItem>>(content);
			}

			return null;
		}


		public async Task<IEnumerable<TaskItem>> GetAllTasksObservableAsync()
		{
			HttpResponseMessage resp = await client.GetAsync(Q_ALLTASKS_GET);
			if (resp.IsSuccessStatusCode)
			{
				var content = await resp.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<List<TaskItem>>(content);
			}

			return null;
		}
	}
}
