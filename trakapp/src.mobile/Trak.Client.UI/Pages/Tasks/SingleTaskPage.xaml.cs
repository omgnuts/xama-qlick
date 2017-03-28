using System;
using System.Text;
using System.Collections.Generic;
using Humanizer;
using Trak.Client.Portable;

using Xamarin.Forms;

namespace Trak.Client.UI
{
	public partial class SingleTaskPage : ContentPage
	{
		public TaskItem Context
		{
			get { return BindingContext as TaskItem; }
		}

		readonly TaskItemViewModel viewModel;

		public SingleTaskPage(TaskItemViewModel viewModel, TaskItem task)
		{
			InitializeComponent();

			this.viewModel = viewModel;

			//taskColor = PantoneColor.FromString(task.SystId);
			//App.NavPage.BarBackgroundColor = taskColor;
			//App.NavPage.BarTextColor = Styles.ThemeColor;
			App.NavPage.BarBackgroundColor = Styles.ColorBlue;
			App.NavPage.BarTextColor = Color.White;
			//App.NavPage.Tint = Styles.ColorRed;

			BackgroundColor = Color.White;
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

		protected override bool OnBackButtonPressed()
		{
			App.NavPage.BarTextColor = Color.Black;
			return base.OnBackButtonPressed();
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
				Title = Context.Title;
				//header.BackgroundColor = taskColor;
				//lblSystId.TextColor = taskColor;
				//App.NavPage.Title = Context.Title;

				lblTitle.Text = Context.Title;
				lblUserCreated.Text = "@" + Context.UserId + " • " + Context.CreatedDT.Humanize();
				lblDescription.Text = Context.Description;
				//lblSystId.Text = Context.SystId;
				lblDueDT.Text = "Delivery is due " + Context.DueDT.Humanize();

				attachmentStack.IsVisible = Context.SystId.Equals("Prism");

				cmdActions.Children.Add(createButton("APPROVE", clGreen));
				cmdActions.Children.Add(createButton("REJECT", clRed));
				//cmdActions.Children.Add(createButton("QUERY", Color.Blue));

				ParseDetails(Context.Details);
			}
		}

		static double lblFontSizeMedium = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
		static double lblFontSizeSmall = Device.GetNamedSize(NamedSize.Small, typeof(Label));

		void ParseDetails(string details) {

			if (details != null)
			{
				string[] pairs = details.Split(',');

				foreach (string pair in pairs)
				{
					string[] kv = pair.Split(':');

					detailStack.Children.Add(new Label()
					{
						Text = kv[0],
						FontSize = lblFontSizeSmall,
						FontAttributes = FontAttributes.Bold,
						TextColor = Color.Silver
					});
					detailStack.Children.Add(new Label()
					{
						Text = kv[1],
						FontSize = lblFontSizeMedium
					});
				}
			}

		}


		static Color clGreen = Color.FromHex("27ae60");
		static Color clRed = Color.FromHex("e74c3c");	
		//static Color clOrange = Color.FromHex("");
		static double fontSizeMedium = Device.GetNamedSize(NamedSize.Medium, typeof(Button));

		Button createButton(string name, Color bnColor)
		{
			Button button = new Button()
			{
				Text = name,
				BackgroundColor = bnColor,
				TextColor = Color.White,
				FontSize = fontSizeMedium,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HeightRequest = 50,
				WidthRequest = 350
			};

			button.Clicked += OnClickListener;
			return button;
		}

		async void OnClickListener(object sender, EventArgs e)
		{
			if (((Button)sender).Text.Equals("APPROVE")) {
				await TrakAPI.Instance.PerformActionAsync(
					Context.Id,
					"APPROVED",
					"Shay",
					"DummyComments");
			}
			await Navigation.PopAsync();
			await viewModel.DeleteCommand(Context);

		}

	}
}
