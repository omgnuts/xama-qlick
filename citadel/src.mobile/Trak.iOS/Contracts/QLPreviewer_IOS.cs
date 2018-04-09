using System;
using System.IO;
using Foundation;
using QuickLook;
using Trak.Client.Portable.Utils;
using Trak.iOS.DependencyService;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(QLPreviewer_IOS))]
namespace Trak.iOS.DependencyService
{
    public class QLPreviewer_IOS : IQLPreviewer
    {
        public void Preview(string fileName, byte[] data)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, fileName);
            File.WriteAllBytes(filePath, data);


            QLPreviewItemFileSystem prevItem = new QLPreviewItemFileSystem(fileName, filePath);
            QLPreviewController previewController = new QLPreviewController();
            previewController.DataSource = new PreviewControllerDS(prevItem);
            UIApplication.SharedApplication.KeyWindow.RootViewController
                    .PresentViewController(previewController, true, null);
                                                                                               
        }

    }


    public class PreviewControllerDS : QLPreviewControllerDataSource
    {
        private QLPreviewItem _item;

        public PreviewControllerDS(QLPreviewItem item)
        {
            _item = item;
        }

        public override IQLPreviewItem GetPreviewItem(QLPreviewController controller, nint index)
        {
            return _item;
        }

        public override nint PreviewItemCount(QLPreviewController controller)
        {
            return 1;
        }
    }

    public class QLPreviewItemFileSystem : QLPreviewItem
    {
        string _fileName, _filePath;

        public QLPreviewItemFileSystem(string fileName, string filePath)
        {
            _fileName = fileName;
            _filePath = filePath;
        }

        public override string ItemTitle
        {
            get
            {
                return _fileName;
            }
        }
        public override NSUrl ItemUrl
        {
            get
            {
                return NSUrl.FromFilename(_filePath);
            }
        }
    }


    //https://forums.xamarin.com/discussion/52403/download-save-and-display-pdf-file
    // for Android
    //public void DownloadPdfFile(byte[] bytes, string Name)
    //{
    //    // Write pdf File
    //    var directory = global::Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
    //    directory = Path.Combine(directory, Android.OS.Environment.DirectoryDownloads);
    //    string filePath = Path.Combine(directory.ToString(), Name);
    //    File.WriteAllBytes(filePath, bytes);

    //    //Open the Pdf file with Defualt app.
    //    Android.Net.Uri pdfPath = Android.Net.Uri.FromFile(new Java.IO.File(filePath));
    //    Intent intent = new Intent(Intent.ActionView);
    //    intent.SetDataAndType(pdfPath, "application/pdf");
    //    intent.SetFlags(ActivityFlags.NewTask);
    //    Forms.Context.StartActivity(intent);
    //}


}