using System;
using System.Collections.Generic;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;
using Trak.Client.Portable;

namespace Trak.Client.UI
{
	public partial class DocumentDetailPage : ContentPage
	{
		public Document Context
		{
			get { return BindingContext as Document; }
		}

		public DocumentDetailPage(Document document)
		{
            InitializeComponent();

			BindingContext = document;
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
				GenerateQrCode(Context.Hash());

				AddDetail("Document", Context.Title);
				if (Context.Description != null) AddDetail("Description", Context.Description);
				AddDetail("Blockchain", EnumConvert.BlockChainCode(Context.BlockChain));
			}
		}

		void GenerateQrCode(string value)
		{
			barcode.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
			barcode.BarcodeOptions.Width = 250;
			barcode.BarcodeOptions.Height = 250;
			barcode.BarcodeOptions.Margin = 0;

			barcode.BarcodeValue = "[Todo] Provide blockchain resource id / api for resource: " + value ;
		}

		static double lblFontSizeMedium = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
		static double lblFontSizeSmall = Device.GetNamedSize(NamedSize.Small, typeof(Label));

		void AddDetail(string key, string value)
		{
			detailStack.Children.Add(new Label()
			{
			Text = key,
				FontSize = lblFontSizeSmall,
				FontAttributes = FontAttributes.Bold,
				TextColor = Color.Silver
			});
			detailStack.Children.Add(new Label()
			{
				Text = value,
				FontSize = lblFontSizeMedium
			});			
		}
	}

}
