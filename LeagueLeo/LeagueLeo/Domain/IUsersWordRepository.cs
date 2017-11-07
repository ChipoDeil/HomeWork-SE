using System;
using System.Collections.Generic;

namespace LeagueLeo
{
    public interface IUsersWordRepository
    {
        IEnumerable<Word> LoadWordsForUser(Guid userId);
        void AddWordForUser(Guid userId, Word word);
        void AddPointsToWordForUser(Guid userId, Word word);
    }
}
