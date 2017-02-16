using System;
using System.Collections.Generic;

using Qlick.Client.Portable;

using Xamarin.Forms;

namespace Qlick.Client.UI
{
	public partial class SingleTaskPage : ContentPage
	{
		public TaskItem Context
		{
			get { return BindingContext as TaskItem; }
		}

		public SingleTaskPage(TaskItem task)
		{
			InitializeComponent();
			BindingContext = task;
		}

		bool started = false;
		void OnStart()
		{
			started = true;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			if (!started)
			{
				OnStart();
			}
		}

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();

			if (BindingContext != null)
			{
				Color pc = PantoneColor.FromString(Context.SystId);
				header.BackgroundColor = pc;

			}
		}
	}
}
