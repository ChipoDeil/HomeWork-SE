using System;
using System.Collections.Generic;

namespace LeagueLeo
{
    public interface IWordRepository
    {
        Word LoadWord(Guid wordId);
        void SaveWord(Word word);
        IEnumerable<Word> LoadAllWords();
    }   
}
