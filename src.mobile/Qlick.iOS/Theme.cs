using UIKit;
using Xamarin.Forms.Platform.iOS;

namespace Qlick.iOS
{
	public static class Theme
	{
		public static void SetAppearance()
		{
			UITabBar.Appearance.SelectedImageTintColor = Qlick.Client.UI.Styles.ThemeColor.ToUIColor();
		}
	}
}
