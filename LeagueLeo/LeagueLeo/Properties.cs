using System.IO;

namespace LeagueLeo
{
    internal static class Properties
    {

        internal static string currentDirectory = Directory.GetCurrentDirectory() + "/data/";

        internal const string userFile = "userdata.json";

        internal const string splitDirectory = "/sprint/";

        internal const string wordFile = "globalwords.json";

        internal const string vocFile = "vocabularies.json";

        internal const int minWordsToStartSplit = 3;

        internal const int minPointsOfWordToTreatAsStudied = 3;

    }
}
