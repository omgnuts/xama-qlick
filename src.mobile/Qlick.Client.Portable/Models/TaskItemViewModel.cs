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
		public SimpleObservableCollection<TaskItem> Items { get; }

		public TaskItemViewModel()
		{
			Items = new SimpleObservableCollection<TaskItem>();
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

			IEnumerable<TaskItem> items = await QlickAPI.Instance.GetAllTasksObservableAsync();

			Items.Clear();
			Items.AddRange(items);

			IsBusy = false;

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
