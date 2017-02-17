using System;
using System.Collections.Generic;
using Humanizer;
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

			taskColor = PantoneColor.FromString(task.SystId);
			App.NavPage.BarBackgroundColor = taskColor;
			App.NavPage.BarTextColor = Color.White;

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

				//lblTitle.TextColor = pc;
				//lblSystId.TextColor = pc;
				//lblSystIdLetter.BackgroundColor = pc;

				lblTitle.Text = Context.Title;
				lblDescription.Text = Context.Description;
				lblUserCreated.Text = "@" + Context.UserId + " • " + Context.CreatedDT.Humanize();
				lblSystId.Text = Context.SystId; 
				//lblDueDT.Text = "Due " + Self.DueDT.Humanize();

				lblSystId.Text = Context.SystId;
			}
		}


	}
}
