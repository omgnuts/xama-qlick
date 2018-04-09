using System.Collections.Generic;
using Trak.Client.Portable.Models;
using Trak.Client.UI.Theme;
using Xamarin.Forms;

namespace Trak.Client.UI
{
	public partial class DocumentListPage : ContentPage
	{
        public Stage Context
		{
            get { return BindingContext as Stage; }
		}

		public DocumentListPage(Stage stage)
		{
            InitializeComponent();
            BindingContext = stage;

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
                initCells(Context.StageItems);
			}
		}


        void initCells(List<StageItem> stageItems)
		{
            if (stageItems != null)
			{
                listView.ItemsSource = stageItems;
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
            StageItem item = (StageItem)e.Item;

            if (item.StageItemTxn != null)
			{
				//Navigation.PushAsync(new DocumentDetailPage(doc));
			}
			else
			{
				DisplayAlert("No Blockchain Information", "There is no blockchain details for this document, as the document has not been secure.", "OK");
			}

		}

	}
}
