using System;
using System.IO;
using System.Net;
using Foundation;
using Trak.Client.UI.PDFViewer;
using Trak.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer (typeof(PDFWebView), typeof(PDFViewRenderer))]
namespace Trak.iOS.Renderers
{
    public class PDFViewRenderer : ViewRenderer<PDFWebView, UIWebView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<PDFWebView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                SetNativeControl(new UIWebView());
            }
            if (e.OldElement != null)
            {
                // Cleanup
            }
            if (e.NewElement != null)
            {
                var pdfViewer = Element as PDFWebView;

                NSData data = NSData.FromArray(pdfViewer.Uri);

                //string fileName = Path.Combine(NSBundle.MainBundle.BundlePath, string.Format("Content/{0}", WebUtility.UrlEncode(pdfViewer.Uri)));
                //Control.LoadRequest(new NSUrlRequest(new NSUrl("https://1citadel-shipping-demo.azurewebsites.net/idms/download2/newshipment1/c453aeb3-10fc-403f-86ac-777aa154dbd5", false)));
        
                Control.LoadData(data, @"application/pdf", "UTF-8", new NSUrl(""));
                Control.ScalesPageToFit = true;
            }
        }
    }
}