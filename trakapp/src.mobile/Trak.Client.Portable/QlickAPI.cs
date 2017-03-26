using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


namespace Trak.Client.Portable
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
		static string Q_ALLTASKS_GET = "qlick.json"; 
		static string Q_ACTION = "api/MiWork/PerformAction";

		//PJAY PC
		//static string Q_BASE = "http://192.168.100.214:4000";
		//static string Q_ALLTASKS_GET = "api/MiWork/GetAllApprovalWorkflow?userID=Shay"; // api/tasks
		//static string Q_ACTION = "api/MiWork/PerformAction";

		// REAL THING
		//static string Q_BASE = "http://192.168.100.224:4000";
		//static string Q_ALLTASKS_GET = "api/MiWork/GetAllApprovalWorkflow?userID=Shay"; // api/tasks
		//static string Q_ACTION = "api/MiWork/PerformAction";

		//static string Q_USERTASKS_GET = "qlick.json"; // api/tasks/{userid}
		//static string Q_USERTASKS_PENDING_GET = "qlick.json"; // api/tasks/{userid}/pending

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


		public async Task<List<TaskItem>> GetAllTasksObservableAsync()
		{
			HttpResponseMessage resp = await client.GetAsync(Q_ALLTASKS_GET);
			if (resp.IsSuccessStatusCode)
			{
				var content = await resp.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<List<TaskItem>>(content);
			}

			return null;
		}


		public async Task<int> PerformActionAsync(
			string id, string act, string userId, string comments)
		{
			string action = Q_ACTION + "?"
				+ "qlickid=" + id
				+ "&act=" + act
				+ "&userid=" + userId
				+ "&comments=" + comments;

			System.Diagnostics.Debug.WriteLine(action);

			HttpResponseMessage resp = await client.GetAsync(action);

			return 1;
		}
	}
}
