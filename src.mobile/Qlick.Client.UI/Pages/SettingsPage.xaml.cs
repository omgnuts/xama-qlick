using System;
using System.Collections.Generic;
using Qlick.Client.Portable;

using Xamarin.Forms;

namespace Qlick.Client.UI
{
	public partial class SettingsPage : ContentPage
	{
		public WorkViewModel ViewModel
		{
			get { return BindingContext as WorkViewModel; }
		}

		public SettingsPage()
		{
			InitializeComponent();
			BindingContext = new WorkViewModel();
		}


        protected override void OnAppearing()
		{
			base.OnAppearing();
			//if (ViewModel == null || !ViewModel.CanLoadMore || ViewModel.IsRefreshing || ViewModel.FeedItems.Count > 0)
			//	return;

			ViewModel.RefreshCommand.Execute(null);
		}
	}
}
