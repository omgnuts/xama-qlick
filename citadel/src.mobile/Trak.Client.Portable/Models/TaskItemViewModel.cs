using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Trak.Client.Portable.Common;
using Xamarin.Forms;

namespace Trak.Client.Portable
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
				if (isBusy != value)
				{
					isBusy = value;
					OnPropertyChanged("IsBusy");
				}
			}
		}

		public SeparatorVisibility HasSeparator
		{
			get { return Items.Count > 0 ? SeparatorVisibility.Default : SeparatorVisibility.None; }
			set { OnPropertyChanged("HasSeparator"); }
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

			List<TaskItem> items = await TrakAPI.Instance.GetAllTasksObservableAsync();

			Items.Clear();
			Items.AddRange(items);

			IsBusy = false;
			HasSeparator = SeparatorVisibility.Default;
		}

		public async Task DeleteCommand(TaskItem item)
		{
			if (Items.Contains(item))
			{
                // perform an await action on server
				Items.Remove(item);
			}
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
