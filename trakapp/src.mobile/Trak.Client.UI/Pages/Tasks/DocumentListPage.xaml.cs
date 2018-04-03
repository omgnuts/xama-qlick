using System;
using System.Collections.Generic;
using Trak.Client.Portable;
using Xamarin.Forms;

namespace Trak.Client.UI
{
	public partial class DocumentListPage : ContentPage
	{
		public RouteItem Context
		{
			get { return BindingContext as RouteItem; }
		}

		public DocumentListPage(RouteItem route)
		{
            InitializeComponent();
			BindingContext = route;

			App.NavPage.BarBackgroundColor = Styles.ColorBlue;
			App.NavPage.BarTextColor = Color.White;

			BackgroundColor = Color.White;

		}

		protected override void OnAppearing()
		{
			App.NavPage.BarTextColor = Color.White;
			base.OnAppearing();
		}

		protected override void OnDisappearing()
		{
			App.NavPage.BarTextColor = Color.Black;
			base.OnDisappearing();
		}

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();

			if (BindingContext != null)
			{
				Title = Context.Title;
				initDocuments(Context.Documents);
			}
		}


		void initDocuments(Document[] documents)
		{
			if (documents != null)
			{
				listView.ItemsSource = documents;
				listView.ItemSelected += OnItemSelectedListener;
				listView.ItemTapped += OnItemTappedListener;

			}
		}

		void OnItemSelectedListener(object sender, SelectedItemChangedEventArgs e)
		{
			listView.SelectedItem = null;
		}

		void OnItemTappedListener(object sender, ItemTappedEventArgs e)
		{
			Document doc = (Document)e.Item;

			//Navigation.PushAsync(new DocumentListPage(route));

			//if (route.BlockChain != 0)
			//{
			//	Navigation.PushAsync(new RouteDetailPage(route));
			//}
			//else
			//{
			//             DisplayAlert("No Blockchain Information", "There are no blockchain details for this waypoint, as the cargo has not yet reached this location.", "OK");

		}

	}
}
