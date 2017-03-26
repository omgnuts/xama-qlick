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
			image.Source = "screen-profile.png";
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
