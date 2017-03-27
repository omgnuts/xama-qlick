using Foundation;
using UIKit;
using SegmentedControl.FormsPlugin.iOS;

namespace Qlick.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
		{
			global::Xamarin.Forms.Forms.Init();

			SegmentedControlRenderer.Init();

			LoadApplication(new Qlick.Client.UI.App());
			UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, false);

			Theme.SetAppearance();

			//NSThread.SleepFor(2);

			return base.FinishedLaunching(uiApplication, launchOptions);
		}
	}
}
