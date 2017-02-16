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
		public ObservableCollection<TaskItem> Items { get; }

		public TaskItemViewModel()
		{
			Items = new ObservableCollection<TaskItem>();
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

			IEnumerable<TaskItem> itms = await QlickAPI.Instance.GetAllTasksObservableAsync();

			foreach (TaskItem ti in itms)
			{
				Items.Add(ti);
			}

			IsBusy = false;

			//return false;
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
