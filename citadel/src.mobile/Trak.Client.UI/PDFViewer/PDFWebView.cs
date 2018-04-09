using Xamarin.Forms;

namespace Trak.Client.UI.PDFViewer
{
    public class PDFWebView : WebView
    {
        public static readonly BindableProperty UriProperty 
            = BindableProperty.Create(propertyName: "Uri",
                returnType: typeof(string),
                declaringType: typeof(PDFWebView),
                defaultValue: default(string));

        public string Uri
        {
            get { return (string)GetValue(UriProperty); }
            set { SetValue(UriProperty, value); }
        }
    }

}
