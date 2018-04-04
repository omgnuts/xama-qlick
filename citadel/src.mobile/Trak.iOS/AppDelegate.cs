using Foundation;
using UIKit;
using SegmentedControl.FormsPlugin.iOS;
using CoreLocation;

namespace Trak.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
		{
			global::Xamarin.Forms.Forms.Init();
			global::Xamarin.FormsMaps.Init();
			global::ZXing.Net.Mobile.Forms.iOS.Platform.Init();
			             
			CLLocationManager locationManager = new CLLocationManager();
			locationManager.RequestWhenInUseAuthorization();

			SegmentedControlRenderer.Init();

			LoadApplication(new Trak.Client.UI.App());
			UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, false);

			Theme.SetAppearance();

			//NSThread.SleepFor(2);

			return base.FinishedLaunching(uiApplication, launchOptions);
		}
	}
}
