using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Qlick.Client.UI
{
	public partial class ProfilePage : ContentPage
	{
		public ProfilePage()
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
