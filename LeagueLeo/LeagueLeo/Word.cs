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
        public Word(string original, string translation, Guid id) {
            Original = original;
            Translation = translation;
            Id = id;
            Points = 0;
        }
        
    }
}
