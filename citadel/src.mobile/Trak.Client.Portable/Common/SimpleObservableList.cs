﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Trak.Client.Portable.Common
{
	public class SimpleObservableCollection<T> : ObservableCollection<T>
	{
		public SimpleObservableCollection() : base() { }

		public SimpleObservableCollection(IEnumerable<T> collection) : base(collection) { }

		public SimpleObservableCollection(List<T> list) : base(list)  { }

		public void AddRange(IEnumerable<T> range)
		{
			foreach (var item in range)
			{
				Items.Add(item);
			}

			this.OnPropertyChanged(new PropertyChangedEventArgs("Count"));
			this.OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
			this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		}

		public void Reset(IEnumerable<T> range)
		{
			this.Items.Clear();

			AddRange(range);
		}
	}

}
