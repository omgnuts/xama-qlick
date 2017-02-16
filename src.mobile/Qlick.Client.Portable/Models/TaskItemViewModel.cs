using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
             
namespace Qlick.Client.Portable
{
    public class TaskItemViewModel : INotifyPropertyChanged
	{
		public ObservableCollection<TaskItem> Items { get; set; }

		public TaskItemViewModel()
		{
			Items = new ObservableCollection<TaskItem>();
			//ExecuteRefreshCommand();
		}

		bool isRefreshing;

		public bool IsRefreshing
		{
			get { return isRefreshing; }
			set
			{
				if (isRefreshing == value)
					return;

				isRefreshing = value;
				OnPropertyChanged(nameof(IsRefreshing));
			}
		}

		ICommand refreshCommand;

		public ICommand RefreshCommand
		{
			get { return refreshCommand ?? (refreshCommand = new Command(async () => await ExecuteRefreshCommand())); }
		}

		async Task ExecuteRefreshCommand()
		{
			//if (IsRefreshing) return;
			IsRefreshing = true;
			Items.Clear();
			IEnumerable<TaskItem> itms = await QlickAPI.Instance.GetAllTasksObservableAsync();

			foreach (TaskItem ti in itms)
			{
				Items.Add(ti);
			}

			//Items = new ObservableCollection<TaskItem>(itms);
			System.Diagnostics.Debug.WriteLine(".... exectiging = " + Items.Count);
			IsRefreshing = false;
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
