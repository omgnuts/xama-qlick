using Xamarin.Forms;

namespace Trak.Client.UI.PDFViewer
{
    public class PDFWebView : WebView
    {
        public static readonly BindableProperty UriProperty 
            = BindableProperty.Create(propertyName: "Uri",
                returnType: typeof(byte[]),
                declaringType: typeof(PDFWebView),
                defaultValue: default(byte[]));

        public byte[] Uri
        {
            get { return (byte[])GetValue(UriProperty); }
            set { SetValue(UriProperty, value); }
        }
    }

}
