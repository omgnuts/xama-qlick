using System;
using Xamarin.Forms;
using System.Threading.Tasks;

using Qlick.Client.Portable;

namespace Qlick.Client.UI
{
	public partial class TasksPage : ContentPage
	{
		public TaskItemViewModel ViewModel
		{
			get { return BindingContext as TaskItemViewModel; }
		}

		public TasksPage()
		{
			InitializeComponent();

			BindingContext = new TaskItemViewModel();

			listView.ItemTapped += OnItemTappedListener;
			listView.ItemSelected += OnItemSelectedListener;
		}

		bool started = false;
		void OnStart()
		{
			started = true;
			segmentControl.SetTintColor(Styles.ThemeColor);
			segmentControl.SelectTab(1);

			ViewModel.RefreshCommand.Execute(null);
		}


		protected override void OnAppearing()
		{
			base.OnAppearing();
			if (!started)
			{
				OnStart();
			}

		}

		void OnSegmentControlSelected(object o, EventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("OnSegmentControlSelected");
			switch (segmentControl.SelectedSegment)
			{
				case 0:
					//ViewModel.PrioritySelected = Priority.High;
					break;
				case 1:
					//ViewModel.PrioritySelected = Priority.Normal;
					break;
			}
		}

		void OnItemSelectedListener(object sender, SelectedItemChangedEventArgs e)
		{
			listView.SelectedItem = null;
		}

		void OnItemTappedListener(object sender, ItemTappedEventArgs e)
		{
			Navigation.PushAsync(new SingleTaskPage(ViewModel, (TaskItem)e.Item));
		}

	}

}
