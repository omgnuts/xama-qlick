using System;
namespace Trak.Client.Portable.Utils
{
    public interface ISaveAndLoad
    {
        string SaveFile(string filename, byte[] data);
        byte[] LoadFile(string filename);
    }

}
