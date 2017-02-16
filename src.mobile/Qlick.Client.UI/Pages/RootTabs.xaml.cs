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

			NavigationPage.SetHasNavigationBar(this, false);

			//if (App.NavPage != null) App.NavPage.BarTextColor = Color.Black;

			Children.Add(new TasksPage { Title = "Tasks", Icon = "tab-tasks.png" });
			Children.Add(new SearchPage { Title = "Search", Icon = "tab-search.png" });
			Children.Add(new ContentPage { Title = "Profile", Icon = "tab-profile.png" });
			Children.Add(new SettingsPage { Title = "Settings", Icon = "tab-settings.png" });
		}
	}
}
