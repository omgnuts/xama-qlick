using UIKit;
using Xamarin.Forms.Platform.iOS;
using Trak.Client.UI.Theme;

namespace Trak.iOS
{
	public static class Theme
	{
		public static void SetAppearance()
		{
			UITabBar.Appearance.SelectedImageTintColor = Styles.ThemeColor.ToUIColor();
			//UIBarButtonItem.Appearance.TintColor = Trak.Client.UI.Styles.ThemeColor.ToUIColor();
		}
	}
}
