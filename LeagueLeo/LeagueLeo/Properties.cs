using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LeagueLeo
{
    internal static class Properties
    {
        internal static string currentDirectory = Directory.GetCurrentDirectory() + "/data/";

        internal const string userFile = "userdata.json";
    }
}
