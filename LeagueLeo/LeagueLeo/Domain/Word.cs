using Newtonsoft.Json;
using System;

namespace LeagueLeo
{
    public class Word
    {
        public string Translation { get; }

        public string Original { get; }

        public Guid Id { get; }

        public int Points { get; private set; }
        public void AddPoint()
        {
            Points++;
        }

        [JsonConstructor]
        public Word(string original, string translation, Guid id, int points)
        {
            Original = original;
            Translation = translation;
            Id = id;
            Points = points;
        }
        public Word(string original, string translation, Guid id)
        {
            Original = original;
            Translation = translation;
            Id = id;
        }
        

    }
}
