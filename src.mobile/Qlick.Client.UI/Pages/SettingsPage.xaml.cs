using System;
using System.Collections.Generic;
using Qlick.Client.Portable;

using Xamarin.Forms;

namespace Qlick.Client.UI
{
	public partial class SettingsPage : ContentPage
	{
		public TaskItemViewModel ViewModel
		{
			get { return BindingContext as TaskItemViewModel; }
		}

		public SettingsPage()
		{
			InitializeComponent();
			BindingContext = new TaskItemViewModel();
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
