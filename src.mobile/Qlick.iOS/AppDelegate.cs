using Foundation;
using UIKit;

namespace Qlick.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
		{
			global::Xamarin.Forms.Forms.Init();

			LoadApplication(new Qlick.Client.UI.App());

			return base.FinishedLaunching(uiApplication, launchOptions);
		}
	}
}
