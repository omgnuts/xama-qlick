using System;
using System.Collections.Generic;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;
using Trak.Client.Portable;

namespace Trak.Client.UI
{
	public partial class RouteDetailPage : ContentPage
	{
		public RouteItem Context
		{
			get { return BindingContext as RouteItem; }
		}

		public RouteDetailPage(RouteItem route)
		{
            InitializeComponent();

			BindingContext = route;
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
				//GenerateQrCode(Context.Hash());

				//AddDetail("Waypoint", Context.Title);
				//if (Context.ArriveDT != null) AddDetail("Arrived", DateDisplay.FormatDate(Context.ArriveDT));
				//if (Context.DepartDT != null) AddDetail("Departed", DateDisplay.FormatDate(Context.DepartDT));
				//AddDetail("Blockchain", BlockChainCode(Context.BlockChain));
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

		string BlockChainCode(int value)
		{
			switch (value)
			{
				case 1: return "Secure";
				case -1: return "Broken";
				default: return "-";
			}
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
