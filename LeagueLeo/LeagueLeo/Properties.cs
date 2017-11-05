using System.IO;

namespace LeagueLeo
{
    internal static class Properties
    {
        internal static string currentDirectory = Directory.GetCurrentDirectory() + "/data/";

        internal const string userFile = "userdata.json";

        internal const string splitDirectory = "/split/";

        internal const string wordFile = "globalwords.json";

        internal const string vocFile = "vocabularies.json";
    }
}
