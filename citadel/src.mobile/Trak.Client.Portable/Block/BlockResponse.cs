using Newtonsoft.Json;

namespace Trak.Client.Portable
{
	public class BlockResponse
	{
		[JsonProperty("txid")]
		public string TransactionId { get; set; }

		[JsonProperty("message")]
		public string Message { get; set; }

		[JsonProperty("success")]
		public bool ResultStatus { get; set; }
	}
}
