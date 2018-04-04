using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Trak.Client.UI
{
	public partial class WatchedPage : ContentPage
	{
		public WatchedPage()
		{
			InitializeComponent();
			//image.Source = "screen-profile.png";
			stacker.BackgroundColor = Color.LightSteelBlue;
			stacker.Children.Add(
				new Frame
				{
					Content = new Label { Text = "This screen activity could be an operational layer to watch shipments that require incident management based on blockchain triggers and on ground sensor insights." },
					OutlineColor = Color.Silver,
					CornerRadius = 5.0f,
					HasShadow = false,
					VerticalOptions = LayoutOptions.Start,
					HorizontalOptions = LayoutOptions.Center,
					Margin = 20
				}
			);
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

	}
}
