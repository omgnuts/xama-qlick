using Newtonsoft.Json;

namespace Trak.Client.Portable
{
	public class CredentialToken
	{
		[JsonProperty("access_token")]
		public string AccessToken { get; set; }

		[JsonProperty("token_type")]
		public string TokenType { get; set; }

		[JsonProperty("expires_at")]
		public string ExpiresAt { get; set; }

		[JsonIgnore]
		public string Dehydrate
		{
			get
			{
				return string.Join(":", new string[] { AccessToken, TokenType, ExpiresAt });
			}
		}

		public static CredentialToken Hydrate(string value)
		{
			string[] creds = value.Split(':');
			return new CredentialToken
			{
				AccessToken = creds[0],
				TokenType = creds[1],
				ExpiresAt = creds[2]
			};
		}
			
	}
}
