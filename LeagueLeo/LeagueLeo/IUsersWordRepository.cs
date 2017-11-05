using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueLeo
{
    public interface IUsersWordRepository
    {
        IEnumerable<Word> LoadWordsForUser(Guid userId);
        void AddWordForUser(Guid userId, Word word);
        void AddPointsToWordForUser(Guid userId, Word word);
    }
}
