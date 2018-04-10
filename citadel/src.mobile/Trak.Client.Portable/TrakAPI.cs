using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Text;
using Trak.Client.Portable.Models;

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

		//const string Q_BASE = "http://loca/lhost:5000";
		const string Q_BASE = "http://rebot.chat:8000";
		const string Q_ALLTASKS_GET = "api/v1/nuances"; 
		const string Q_RESET = "api/v1/demo/reset";
		const string Q_ADDSHIPMENT = "api/v1/demo/add-shipment";
		const string Q_TRIGGERBC = "api/v1/demo/trigger-blockchain";


		const string BC_BASE = "https://1citadelidms-dev.azurewebsites.net";
		const string BC_TOKEN = "Authentication/RequestImpersonatedToken";
		const string BC_CORECREATE = "Core/Create";

        const string DATABASE = "demo1";

        const string BC_MASTERLIST = "Core/List/{0}/master/shipment?page=0&pageSize=0&sortDescendingOrder=true&raw=true";
        const string BC_GETSTAGES = "Core/Get/{0}/{1}/stage/Stage?page=0&pageSize=0&sortDescendingOrder=true&raw=true";
        const string BC_GETDOCUMENT = "Core/Get/{0}/{1}/document/{2}?page=0&pageSize=0&sortDescendingOrder=true&raw=true";

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

		HttpClient CreateHttpClient(string uri = Q_BASE)
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(uri);
			//client.DefaultRequestHeaders.Add("Content-Type", "application/json; charset=utf-8");
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


		public async Task<CredentialToken> GetAuthenticationTokenAsync(CredentialRequest request)
		{
			var data = JsonConvert.SerializeObject(request);
			var rqContent = new StringContent(data, Encoding.UTF8, "application/json");

			HttpResponseMessage resp = await CreateHttpClient(BC_BASE).PostAsync(BC_TOKEN, rqContent);

			if (resp.IsSuccessStatusCode)
			{
				var content = await resp.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<CredentialToken>(content);
			}

			return null;
		}


        public async Task<List<Shipment>> GetShipmentsAsync() {

            List<Shipment> shipments = new List<Shipment>();

            HttpClient authClient = CreateAuthHttpClient();
            if (authClient == null) {
                return shipments;
            }

            string uri = string.Format(BC_MASTERLIST, DATABASE);

            HttpResponseMessage resp = await authClient.GetAsync(uri);

            if (resp.IsSuccessStatusCode)
            {
                var content = await resp.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Shipment>>(content);
            }

            return shipments;
        }

        public async Task<List<Stage>> GetStagesAsync(string key) {
            
            List<Stage> stages = StageFactory.GenerateDefaults();

            HttpClient authClient = CreateAuthHttpClient();
            if (authClient == null)
            {
                return stages;
            }

            string uri = string.Format(BC_GETSTAGES, DATABASE, key);

            HttpResponseMessage resp = await authClient.GetAsync(uri);

            if (resp.IsSuccessStatusCode)
            {
                var content = await resp.Content.ReadAsStringAsync();
                List<StageItemTxn> sits =  JsonConvert.DeserializeObject<List<StageItemTxn>>(content);

                int cc = 1; 

                foreach (Stage ss in stages) {
                    foreach (StageItem si in ss.StageItems) {
                        if (cc > sits.Count)
                        {
                            break;
                        }
                        else
                        {
                            si.StageItemTxn = sits[cc - 1];
                            cc++;
                        }
                    }
                }

            }

            return stages;

        }

        public async Task<Document[]> GetDocumentAsync(string shipmentKey, string docKey) 
        {
            HttpClient authClient = CreateAuthHttpClient();
            if (authClient == null)
            {
                return null;
            }

            string uri = string.Format(BC_GETDOCUMENT, DATABASE, shipmentKey, docKey);

            HttpResponseMessage resp = await authClient.GetAsync(uri);

            if (resp.IsSuccessStatusCode)
            {
                var content = await resp.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Document[]>(content);
            }

            return null;
        }

        HttpClient CreateAuthHttpClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BC_BASE);

            if (AuthorityManager.Instance.Token == null) {
                AuthorityManager.Instance.RequireNewCredentials();
                return null;
            }

            string accessToken = AuthorityManager.Instance.Token.AccessToken;
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
            //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
            return client;
        }


	}
}
