using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Compression;
using System.IO;

namespace Tabaprompter
{
    public static class ZipTools
    {
        
        internal static void zip(string filename, string temp)
        {
            if (File.Exists(temp))
            {
                File.Delete(temp);
            }
            ZipFile.CreateFromDirectory(temp, filename);
        }

        internal static void unzip(string path, string temp)
        {
            if (File.Exists(temp))
            {
                File.Delete(temp);
            }
            ZipFile.ExtractToDirectory(path, temp);
        }
    }
}
