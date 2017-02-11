using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Qlick
{
	public partial class QlickTabs : TabbedPage
	{
		public QlickTabs()
		{
			InitializeComponent();
			Children.Add(new QTasks() { Title = "Tasks", Icon = "tab-task.png" });
			Children.Add(new QSearch { Title = "Search", Icon = "tab-search.png" });
			Children.Add(new QSettings { Title = "Settings", Icon = "tab-settings.png" });
		}
	}
}
