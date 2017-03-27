using System;
using System.Collections.Generic;
using Trak.Client.Portable;
           
using Xamarin.Forms;

namespace Trak.Client.UI
{
	public partial class SearchPage : ContentPage
	{
		public List<SearchItem> items = new List<SearchItem>();

		public SearchPage()
		{
			InitializeComponent();
			items.Add(new SearchItem("#Ayoh Shipping Ltd (last 90 days)", "6,669 shipments"));
			items.Add(new SearchItem("#Electronic Cargo (last 90 days)", "23,319 shipments"));
			items.Add(new SearchItem("#To:Canada (last 90 days)", "56,701 shipments"));

			listView.ItemsSource = items;

			listView.ItemSelected += OnItemSelectedListener;
		}

		void OnItemSelectedListener(object sender, SelectedItemChangedEventArgs e)
		{
			listView.SelectedItem = null;
		}
	}
}
