using System;
using System.IO;
using Trak.Client.Portable.Utils;
using Trak.iOS.DependencyService;
using Xamarin.Forms;

[assembly: Dependency(typeof(SaveAndLoad_IOS))]
namespace Trak.iOS.DependencyService
{
    public class SaveAndLoad_IOS : ISaveAndLoad
    {
        public string SaveFile(string filename, byte[] data)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            File.WriteAllBytes(filePath, data);


            return filePath;
        }

        public byte[] LoadFile(string filename)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            return File.ReadAllBytes(filePath);
        }

    }
}