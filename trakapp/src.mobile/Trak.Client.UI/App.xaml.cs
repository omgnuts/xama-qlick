using System;
using System.Collections.Generic;

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
			//_navigationPage.SetValue(NavigationPage.BarTextColorProperty, Color.White);
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
