using System;
using Xamarin.Forms;
using System.Threading.Tasks;

using Qlick.Client.Portable;

namespace Qlick.Client.UI
{

	public partial class TasksPage : ContentPage
	{
		//public bool IsBusy = true;

		public TasksPage()
		{
			InitializeComponent();

			IsBusy = true;

			//QlickAPI.Instance.GetAllTasksAsync().ContinueWith(t =>
			//{
			//	if (t,Status = TaskStatus.RanToCompletion)
			//	{
					
			//	}
			//});

			//listView.ItemsSource = MockFactory.GenerateMockTasks();
			listView.ItemTapped += OnItemTappedListener;
			listView.ItemSelected += OnItemSelectedListener;

		}

		bool started = false;
		async Task<bool> OnStart()
		{
			started = true;

			listView.ItemsSource = await QlickAPI.Instance.GetAllTasksAsync();

			return true;
		}


		protected override async void OnAppearing()
		{
			base.OnAppearing();

			if (!started)
			{
				IsBusy = !await OnStart();
			}

			segmentControl.SetTintColor(Styles.ThemeColor);
			segmentControl.SelectTab(1);
		}


		void OnSegmentControlSelected(object o, EventArgs e)
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
			listView.SelectedItem = null;

		}

		void OnItemTappedListener(object sender, ItemTappedEventArgs e)
		{
			//System.Diagnostics.Debug.WriteLine(e.Item);
			//DisplayAlert("ItemTapped", e.Item.ToString(), "Ok");

			Navigation.PushAsync(new SingleTaskPage((TaskItem)e.Item));


		}

	}

}
