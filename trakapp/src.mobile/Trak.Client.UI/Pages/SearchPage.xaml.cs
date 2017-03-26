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
			items.Add(new SearchItem("#Prism (last 90 days)", "145 approvals"));
			items.Add(new SearchItem("#eFlow (last 90 days)", "103 approvals"));
			items.Add(new SearchItem("#eLeave (last 90 days)", "33 approvals"));
			items.Add(new SearchItem("#eClaims (last 90 days)", "21 approvals"));
			items.Add(new SearchItem("#EPS (last 90 days)", "8 approvals"));

			listView.ItemsSource = items;

			listView.ItemSelected += OnItemSelectedListener;
		}

		void OnItemSelectedListener(object sender, SelectedItemChangedEventArgs e)
		{
			listView.SelectedItem = null;
		}
	}
}
