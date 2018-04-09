//using System;
//using System.Threading.Tasks;
//using Xamarin.Forms;

//namespace Trak.Client.UI.Utils
//{
//    public static class FileSaver
//    {
//        public static async Task<string> SaveFile(byte[] fileBytes, string filename)
//        {
//            try
//            {
//                string filepath = null;

//                if (Device.RuntimePlatform == Device.Android)
//                {
//                    var pdfWriter = DependencyService.Get<IAndroidPDFWriter>();
//                    filepath = pdfWriter.CreateFile(filename, fileBytes.ToArray());
//                }
//                else if (Device.RuntimePlatform == Device.iOS)
//                {
//                    var rootFolder = FileSystem.Current.GetFolderFromPathAsync(DependencyService.Get<IFileHelper>().GetLocalFilePath()).Result;

//                    using (var pdfBytes = new MemoryStream(fileBytes))
//                    {

//                        var file = await rootFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);

//                        var newFile = await file.OpenAsync(FileAccess.ReadAndWrite);
//                        using (var outputStream = newFile)
//                        {
//                            pdfBytes.CopyTo(outputStream);
//                        }
//                    }
//                }

//                if (string.IsNullOrEmpty(filepath))
//                {
//                    Log.LogThis("file path empty", "DataFileManager", DateTime.Now);
//                    return "Error: Unable to save file";
//                }
//                else
//                {
//                    return filepath;
//                }
//            }
//            catch (Exception ex)
//            {
//                Log.LogThis("Exception", ex.Message, DateTime.Now);
//                return "Error: " + ex.Message;
//            }

//        }
//    }

//}
