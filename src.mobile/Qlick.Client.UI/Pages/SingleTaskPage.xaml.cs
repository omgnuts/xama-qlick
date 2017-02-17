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
				lblSystId.TextColor = taskColor;

				lblTitle.Text = Context.Title;
				lblDescription.Text = Context.Description;
				lblUserCreated.Text = "@" + Context.UserId + " • " + Context.CreatedDT.Humanize();
				lblSystId.Text = Context.SystId;

				cmdActions.Children.Add(createButton("Approve", clGreen));
				cmdActions.Children.Add(createButton("Reject", clRed));
				//cmdActions.Children.Add(createButton("Verify", Color.Red));
			}
		}

		static Color clGreen = Color.FromHex("4ed52a");
		static Color clRed = Color.FromHex("ff5454");
		//static Color clOrange = Color.FromHex("");
		static double fontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button));

		Button createButton(string name, Color bnColor)
		{
			return new Button()
			{
				Text = name,
				BackgroundColor = bnColor,
				TextColor = Color.White,
				FontSize = fontSize,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HeightRequest = 50,
				WidthRequest = 320
				                               
			};
		}

	}
}
