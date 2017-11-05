using System;

namespace LeagueLeo
{
    public interface IWordRepository
    {
        Word LoadWord(Guid wordId);
        void SaveWord(Word word);
    }   
}
