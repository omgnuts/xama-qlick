using Trak.Client.Portable;
using Xamarin.Forms;

namespace Trak.Client.UI
{
	public partial class App : Application
	{
		public static NavigationPage NavPage { get; private set; } 

		public App()
		{
			InitializeComponent();

			MainPage = NavPage = new NavigationPage(new RootTabs())
			{
				BarTextColor = Color.Black
			};
		}

		protected override void OnStart()
		{
			// Handle when your app starts
            Subscribe();
        }

		protected override void OnSleep()
		{
			// Handle when your app sleeps
			Unsubscribe();
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}

		void Subscribe()
		{
			MessagingCenter.Subscribe<AuthorityManager, bool>(this, AuthorityManager.ON_REQUIRE_CREDENTIALS, (sender, cancellable) =>
			{
				MainPage.Navigation.PushModalAsync(new LoginPage());
			});
		}

		void Unsubscribe()
		{
			MessagingCenter.Unsubscribe<AuthorityManager, bool>(this, AuthorityManager.ON_REQUIRE_CREDENTIALS);
		}
	}
}
