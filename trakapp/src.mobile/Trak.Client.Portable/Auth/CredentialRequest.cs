using System;
using Newtonsoft.Json;

namespace Trak.Client.Portable
{
	public class CredentialRequest
	{
		[JsonProperty("impersonatedUsername")]
		public string ImpersonateUsername { get; set; }

		[JsonProperty("username")]
		public string Username { get; set; }

		[JsonProperty("password")]
		public string Password { get; set; }
	}
}
