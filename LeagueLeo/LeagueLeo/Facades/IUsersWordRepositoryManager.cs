using System;
using System.Collections.Generic;

namespace LeagueLeo.Facades
{
    public interface IUsersWordRepositoryManager
    {
        Guid AddWordForUser(Word word, Guid userId);
        IEnumerable<Word> LoadWordsForUser(Guid userId);
    }
}
