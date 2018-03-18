using System;
using Trak.Client.Portable;

using Xamarin.Forms;

namespace Trak.Client.UI
{
	public partial class SettingsPage : ContentPage
	{
		public SettingsPage()
		{
			InitializeComponent();

			BackgroundColor = Color.LightSteelBlue;

			cmdActions.Children.Add(createButton("RESET DATABASE", clGreen));
			cmdActions.Children.Add(createButton("ADD SHIPMENT", clGreen));
			cmdActions.Children.Add(createButton("TRIGGER BLOCKCHAIN", clGreen));
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			App.NavPage.BarTextColor = Color.White;
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			App.NavPage.BarTextColor = Color.Black;
		}

		static Color clGreen = Color.White; //Color.FromHex("27ae60");
		static double fontSizeMedium = Device.GetNamedSize(NamedSize.Medium, typeof(Button));

		Button createButton(string name, Color bnColor)
		{
			Button button = new Button()
			{
				Text = name,
				BackgroundColor = bnColor,
				TextColor = Color.SteelBlue,
				FontSize = fontSizeMedium,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.Center,
				HeightRequest = 100,
				WidthRequest = 300,
				Margin = 10
			};

			button.Clicked += OnClickListener;
			return button;
		}

		async void OnClickListener(object sender, EventArgs e)
		{
			switch (((Button)sender).Text)
			{
				case "RESET DATABASE": 
					await TrakAPI.Instance.PerformActionAsync("RESET_DATABASE");
					break;
					
				case "ADD SHIPMENT": 
					await TrakAPI.Instance.PerformActionAsync("ADD_SHIPMENT");
					break;

				case "TRIGGER BLOCKCHAIN": 
					await TrakAPI.Instance.PerformActionAsync("TRIGGER_BLOCKCHAIN");
					break;
			}
		}
	}
}
