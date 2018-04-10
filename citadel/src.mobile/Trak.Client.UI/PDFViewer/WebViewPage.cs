using System;

using Xamarin.Forms;

namespace Trak.Client.UI.PDFViewer
{
    public class WebViewPage : ContentPage
    {
        WebView _webView;

        public WebViewPage(string uri)
        {
            _webView = new WebView()
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

