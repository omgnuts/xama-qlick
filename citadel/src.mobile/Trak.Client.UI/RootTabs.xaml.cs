using System;
using System.Collections.Generic;
using Trak.Client.UI.Pages.Tasks;
using Xamarin.Forms;

namespace Trak.Client.UI
{
	public partial class RootTabs : TabbedPage
	{
		public RootTabs()
		{
			InitializeComponent();

			NavigationPage.SetHasNavigationBar(this, false);

			Children.Add(new ShipmentList { Title = "Shipments", Icon = "tab-tasks.png" });
			Children.Add(new SearchPage { Title = "Search", Icon = "tab-search.png" });
			Children.Add(new WatchedPage { Title = "Incidents", Icon = "tab-watched.png" });
			Children.Add(new StatsPage { Title = "Statistics", Icon = "tab-statistics.png" });
			Children.Add(new SettingsPage { Title = "Settings", Icon = "tab-settings.png" });

		}
	}
}
