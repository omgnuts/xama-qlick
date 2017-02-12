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
			Children.Add(new TasksPage { Title = "Tasks", Icon = "tab-task.png" });
			Children.Add(new SearchPage { Title = "Search", Icon = "tab_sessions.png" });
			Children.Add(new SettingsPage { Title = "Settings", Icon = "tab-settings.png" });
		}
	}
}
