using System.IO;

namespace LeagueLeo
{
    public static class Properties
    {

        public static string currentDirectory = Directory.GetCurrentDirectory() + "/data/";

        public static string userFile = "userdata.json";

        public static string splitDirectory = "/sprint/";

        public static string wordFile = "globalwords.json";

        public static string vocFile = "vocabularies.json";

        public static int minWordsToStartSplit = 3;

        public static int minPointsOfWordToTreatAsStudied = 3;

    }
}
