using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Qlick.Client.Portable
{
	public class WorkViewModel : INotifyPropertyChanged
	{
		public ObservableCollection<WorkItem> Items { get; }

		public WorkViewModel()
		{
			Items = new ObservableCollection<WorkItem>();
		}

		bool isBusy;

		public bool IsBusy
		{
			get { return isBusy; }
			set
			{
				if (isBusy == value)
					return;

				isBusy = value;
				OnPropertyChanged("IsBusy");
			}
		}

		ICommand refreshCommand;

		public ICommand RefreshCommand
		{
			get { return refreshCommand ?? (refreshCommand = new Command(async () => await ExecuteRefreshCommand())); }
		}

		async Task ExecuteRefreshCommand()
		{
			if (IsBusy)
				return;

			IsBusy = true;
			Items.Clear();

			Device.StartTimer(TimeSpan.FromSeconds(5), () =>
				{
					for (int i = 0; i < 100; i++)
					Items.Add(new WorkItem("work " + i));

					IsBusy = false;

					//page.DisplayAlert("Refreshed", "You just refreshed the page! Nice job!", "OK");
					return false;
				});
		}

		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion

		public void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged == null)
				return;

			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

	}
}
