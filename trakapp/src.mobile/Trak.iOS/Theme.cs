using UIKit;
using Xamarin.Forms.Platform.iOS;

namespace Trak.iOS
{
	public static class Theme
	{
		public static void SetAppearance()
		{
			UITabBar.Appearance.SelectedImageTintColor = Trak.Client.UI.Styles.ThemeColor.ToUIColor();
		}
	}
}
