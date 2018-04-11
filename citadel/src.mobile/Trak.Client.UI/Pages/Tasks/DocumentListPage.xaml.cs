using System;
using System.IO;
using System.Collections.Generic;
using Trak.Client.Portable;
using Trak.Client.Portable.Models;
using Trak.Client.UI.Theme;
using Xamarin.Forms;
using Trak.Client.UI.Utils;
using Trak.Client.Portable.Utils;
using Trak.Client.UI.PDFViewer;
using Trak.Client.Portable.Common;

namespace Trak.Client.UI
{
	public partial class DocumentListPage : ContentPage
	{
        public Stage Context
		{
            get { return BindingContext as Stage; }
		}

        readonly string ShipmentKey;

		public DocumentListPage(string shipmentKey, Stage stage)
		{
            InitializeComponent();
            ShipmentKey = shipmentKey;

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

		async void OnItemTappedListener(object sender, ItemTappedEventArgs e)
		{
            StageItem item = (StageItem)e.Item;

            if (item.StageItemTxn != null)
			{
                Document[] docs = await TrakAPI.Instance.GetDocumentAsync(
                    ShipmentKey, item.StageItemTxn.Key);
                if (docs != null && docs.Length > 0)
                {
                    //// Method 0: Demo 
                    ///string base64 = SampleBase64.SampleData(docs[0].FileType);
                    //if (base64 != null)
                    //{
                    //    byte[] data = Convert.FromBase64String(base64);
                    //    DependencyService.Get<IQLPreviewer>().Preview(docs[0].FilenameWithExtension, data);
                    //}

                    // Method 1: QuickLookPreviewer
                    DependencyService.Get<IQLPreviewer>().Preview(docs[0].FilenameWithExtension, docs[0].DecompressedData);

                    // Method 2: Using PDFPageViewer (aka UIWebView.LoadData)
                    //await Navigation.PushAsync(new PDFPageViewer(docs[0].FileData));

                    //Navigation.PushAsync(new DocumentDetailPage(doc));
                } 
                else 
                {
                    await DisplayAlert("Document Error", "Please check with the support team.", "OK");
                }
			}
			else
			{
				await DisplayAlert("No Document", "There is no blockchain document, as the document has not been secure.", "OK");
			}

		}

	}
}
