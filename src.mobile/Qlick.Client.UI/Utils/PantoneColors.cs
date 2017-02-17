using System;

using Xamarin.Forms;

namespace Qlick.Client.UI
{
	public static class PantoneColor 
	{
		static Color[] colors = new Color[] {
			Color.FromHex("#16a085"),
			//Color.FromHex("#27ae60"),
			Color.FromHex("#2980b9"),
			Color.FromHex("#8e44ad"),
			Color.FromHex("#2c3e50"),
			Color.FromHex("#f1c40f"),
			Color.FromHex("#e67e22"),
			//Color.FromHex("#e74c3c")
		};

		static int colorsLength = colors.Length;

		public static Color FromString(string value)
		{
			int hash = value.Length;
			foreach (byte b in System.Text.Encoding.UTF8.GetBytes(value.ToCharArray()))
			{
				hash += b;	
			}
			return colors[hash % colorsLength];
		}

	}
}

