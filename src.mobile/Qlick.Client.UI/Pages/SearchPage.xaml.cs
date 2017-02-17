using System;
using System.Collections.Generic;
using Qlick.Client.Portable;
           
using Xamarin.Forms;

namespace Qlick.Client.UI
{
	public partial class SearchPage : ContentPage
	{
		public List<SearchItem> items = new List<SearchItem>();

		public SearchPage()
		{
			InitializeComponent();
			items.Add(new SearchItem("#Prism (last 30 days)", "500 approvals"));
			items.Add(new SearchItem("#Jenkins (last 30 days)", "500 approvals"));
			items.Add(new SearchItem("#Reki (last 30 days)", "500 approvals"));
			items.Add(new SearchItem("#DAW (last 30 days)", "500 approvals"));

			listView.ItemsSource = items;

			listView.ItemSelected += OnItemSelectedListener;
		}

		void OnItemSelectedListener(object sender, SelectedItemChangedEventArgs e)
		{
			listView.SelectedItem = null;
		}
	}
}
