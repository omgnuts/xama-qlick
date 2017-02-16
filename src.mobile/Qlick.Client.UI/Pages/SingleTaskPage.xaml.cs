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

		readonly Color taskColor;

		public SingleTaskPage(TaskItem task)
		{
			InitializeComponent();
			BindingContext = task;

			taskColor = PantoneColor.FromString(task.SystId);
			App.NavPage.BarBackgroundColor = taskColor;
			App.NavPage.BarTextColor = Color.White;

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

		protected override void OnDisappearing()
		{
			App.NavPage.BarTextColor = Color.Black;
			base.OnDisappearing();
		}

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();

			if (BindingContext != null)
			{
				header.BackgroundColor = taskColor;

			}
		}


	}
}
