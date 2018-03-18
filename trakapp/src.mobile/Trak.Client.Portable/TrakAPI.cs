using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


namespace Trak.Client.Portable
{
	public class TrakAPI
	{
		static TrakAPI instance;
		public static TrakAPI Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new TrakAPI();
				}
				return instance;
			}
		}

		static string Q_BASE = "http://rebot.chat:8000";
		static string Q_ALLTASKS_GET = "api/v1/nuances"; 

		static string Q_RESET = "api/v1/demo/reset";
		static string Q_ADDSHIPMENT = "api/v1/demo/add-shipment";
		static string Q_TRIGGERBC = "api/v1/demo/trigger-blockchain";

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
		//HttpClient client;

		//TrakAPI()
		//{
		//	client = new HttpClient();
		//	client.BaseAddress = new Uri(Q_BASE);
		//}

		//      public async Task<List<TaskItem>> GetAllTasksAsync()
		//{
		//	HttpResponseMessage resp = await client.GetAsync(Q_ALLTASKS_GET);

		//	if (resp.IsSuccessStatusCode)
		//	{
		//		var content = await resp.Content.ReadAsStringAsync();
		//		return JsonConvert.DeserializeObject<List<TaskItem>>(content);
		//	}

		//	return null;
		//}

		HttpClient CreateHttpClient()
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(Q_BASE);
			return client;
		}

		public async Task<List<TaskItem>> GetAllTasksObservableAsync()
		{
			HttpResponseMessage resp = await CreateHttpClient().GetAsync(Q_ALLTASKS_GET);
			if (resp.IsSuccessStatusCode)
			{
				var content = await resp.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<List<TaskItem>>(content);
			}

			return null;
		}

		public async Task<int> PerformActionAsync(string act)
		{
			string action = Q_RESET;
			switch (act)
			{
				case "RESET_DATABASE": action = Q_RESET;
					break;
				case "ADD_SHIPMENT": action = Q_ADDSHIPMENT;
					break;
				case "TRIGGER_BLOCKCHAIN": action = Q_TRIGGERBC;
					break;
			}

			await CreateHttpClient().GetAsync(action);

			return 1;
		}
	}
}
