using System;
using System.Collections.Generic;

namespace LeagueLeo
{
    public interface IGlobalDictionaryManager
    {
        Word GetWord(Guid wordId);
        Guid AddWord(Word word);
        IEnumerable<Word> GetAllWords();

    }
}
