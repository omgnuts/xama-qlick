using System;

using Xamarin.Forms;

namespace Trak.Client.UI.PDFViewer
{
    public class WebViewPage : ContentPage
    {
        PDFWebView _webView;

        public WebViewPage(string uri)
        {
            _webView = new PDFWebView()
            {
                Source = uri,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand

            };

            Content = new StackLayout
            {
                Children = { _webView }
            };

        }
    }
}

