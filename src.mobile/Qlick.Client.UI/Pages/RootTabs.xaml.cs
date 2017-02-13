using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Qlick.Client.UI
{
	public partial class RootTabs : TabbedPage
	{
		public RootTabs()
		{
			InitializeComponent();
			Children.Add(new TasksPage { Title = "Tasks", Icon = "tab-tasks.png" });
			Children.Add(new SearchPage { Title = "Search", Icon = "tab-search.png" });
			Children.Add(new ContentPage { Title = "Profile", Icon = "tab-profile.png" });
			Children.Add(new SettingsPage { Title = "Settings", Icon = "tab-settings.png" });
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

		}
	}
}
