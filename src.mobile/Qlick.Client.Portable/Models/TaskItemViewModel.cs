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
		List<TaskItem> items;
		public SimpleObservableCollection<TaskItem> Items { get; }

		public TaskItemViewModel()
		{
			items = new List<TaskItem>();
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

        private Priority prioritySelected;
		public Priority PrioritySelected
		{
			get { return prioritySelected; }
			set 
			{ 
				if (prioritySelected != value) 
				{ 
					prioritySelected = value; 
					OnPropertyChanged("PrioritySelected"); 
				} 

			}
		}

		ICommand priorityCommand;
		public ICommand PriorityCommand
		{
			get { return priorityCommand ?? (priorityCommand = new Command(async () => await ExecutePriorityCommand())); }
		}

		async Task ExecutePriorityCommand()
		{
			System.Diagnostics.Debug.WriteLine("ExecutePriorityCommand");
			if (items != null)
			{
				List<TaskItem> entities = items.FindAll((obj) =>
				{
					return obj.Priority == prioritySelected;
				});

				Items.Clear();
				if (entities != null)
				{
					Items.AddRange(entities);
				}
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

			items = await QlickAPI.Instance.GetAllTasksObservableAsync();

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
