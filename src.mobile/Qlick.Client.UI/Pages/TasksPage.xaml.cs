using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Qlick.Client.Portable;

namespace Qlick.Client.UI
{

	public partial class TasksPage : ContentPage
	{
		public TasksPage()
		{
			InitializeComponent();

			listView.ItemsSource = MockFactory.GenerateMockTasks();
			listView.ItemTapped += OnTapListener;

		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			SegControl.SetTintColor(Styles.ThemeColor);
			SegControl.SelectTab(1);
		}


		public void Handle_ValueChanged(object o, EventArgs e)
		{
			switch (SegControl.SelectedSegment)
			{
				case 0:
					break;
				case 1:
					break;
			}
		}

		void OnTapListener(object sender, ItemTappedEventArgs e)
		{
			DisplayAlert("ItemTapped", e.Item.ToString(), "Ok");
		}

	}

}
