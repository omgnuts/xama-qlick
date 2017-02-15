using System;
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
			listView.ItemTapped += OnItemTappedListener;
			listView.ItemSelected += OnItemSelectedListener;

		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			segmentControl.SetTintColor(Styles.ThemeColor);
			segmentControl.SelectTab(1);
		}


		public void OnSegmentControlSelected(object o, EventArgs e)
		{
			switch (segmentControl.SelectedSegment)
			{
				case 0:
					break;
				case 1:
					break;
			}
		}

		void OnItemSelectedListener(object sender, SelectedItemChangedEventArgs e)
		{
			//System.Diagnostics.Debug.WriteLine(e.SelectedItem);

			//Navigation.PushAsync(new SettingsPage());

		}

		void OnItemTappedListener(object sender, ItemTappedEventArgs e)
		{
			//System.Diagnostics.Debug.WriteLine(e.Item);
			DisplayAlert("ItemTapped", e.Item.ToString(), "Ok");
		}

	}

}
