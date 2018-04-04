using System;
namespace Trak.Client.UI
{
	public static class DateDisplay
	{
		public static string FormatDate(DateTime? dt)
		{
			if (!dt.HasValue) return "";
			return dt.Value.ToString("HH:mm") + " Hrs on " + dt.Value.ToString("d MMM yyyy");
		}
		
	}
}
