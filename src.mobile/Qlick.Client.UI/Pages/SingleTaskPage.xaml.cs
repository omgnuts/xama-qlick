using System;
using System.Text;
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

				cmdActions.Children.Add(createButton("APPROVE", clGreen));
				cmdActions.Children.Add(createButton("REJECT", clRed));
				//cmdActions.Children.Add(createButton("QUERY", Color.Blue));

				lblDetails.Text = ParseDetails(Context.Details);
			}
		}

		static string ParseDetails(string details) {

			if (details != null)
			{
				string[] pairs = details.Split(';');

				StringBuilder sb = new StringBuilder();
				foreach (string pair in pairs)
				{
					sb.AppendLine(pair);
				}

				return sb.ToString();
			}

			return "";

		}

		static Color clGreen = Color.FromHex("27ae60");
		static Color clRed = Color.FromHex("e74c3c");	
		//static Color clOrange = Color.FromHex("");
		static double fontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button));

		Button createButton(string name, Color bnColor)
		{
			Button button = new Button()
			{
				Text = name,
				BackgroundColor = bnColor,
				TextColor = Color.White,
				FontSize = fontSize,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HeightRequest = 50,
				WidthRequest = 350
			};

			button.Clicked += OnClickListener;
			return button;
		}

		void OnClickListener(object sender, EventArgs e)
		{
			QlickAPI.Instance.PerformActionAsync(
				Context.Id,
				"APPROVE",
				"Shay",
				"DummyComments");                     
		}

	}
}
