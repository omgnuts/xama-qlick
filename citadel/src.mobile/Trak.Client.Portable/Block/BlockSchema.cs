namespace Trak.Client.Portable
{
	public class BlockSchema
	{
		public string Database { get; set; }

		public string Schema { get; set; }

		public string Table { get; set; }

		public string API()
		{
			return $"/{Database}/{Schema}/{Table}";
		}
	}
}
