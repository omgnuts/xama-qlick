using System;
namespace Trak.Client.Portable.Utils
{
    public interface IQLPreviewer
    {
        void Preview(string fileCache, byte[] data);
    }

}
