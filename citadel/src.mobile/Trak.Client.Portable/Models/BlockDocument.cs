using Newtonsoft.Json;

namespace Trak.Client.Portable
{
	public class BlockDocument
	{
		[JsonProperty("document_id")]
		public int DocumentID { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("blockchain")]
		public BlockChained BlockChain { get; set; }

		public string Hash()
		{
			return Title + Description + BlockChain + this.GetHashCode();
		}
	}
}
