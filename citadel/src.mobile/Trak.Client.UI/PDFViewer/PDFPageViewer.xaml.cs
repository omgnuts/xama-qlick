using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Trak.Client.UI.PDFViewer
{
    public partial class PDFPageViewer : ContentPage
    {
        public PDFPageViewer(byte[] uri)
        {
            InitializeComponent();

            pdfViewer.Uri = uri;
        }
    }
}
