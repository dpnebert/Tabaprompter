using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Tabaprompter
{
    public static class FileTools
    {

        internal static String open(string location)
        {
            return File.ReadAllText(location);
            //return text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
        }


        internal static void save(string location, List<string> contents)
        {
            File.WriteAllLines(location, contents.ToArray());
        }





    }
}
