using System;
using System.Collections.Generic;

using Qlick.Client.Portable;

using Xamarin.Forms;

namespace Qlick.Client.UI
{
	public partial class SingleTaskPage : ContentPage
	{
		readonly TaskItem task;

		public SingleTaskPage(TaskItem task)
		{
			InitializeComponent();

			this.task = task;
		}
	}
}
