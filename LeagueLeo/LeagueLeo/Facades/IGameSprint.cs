using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueLeo.Facades
{
    public interface IGameSprint
    {
        Word GetRandomCombination();
        bool IsAnswerRight(string original, string translation, bool right);
        IEnumerable<Word> GetUnstudiedWords();
        void StartGameForUser(Guid userId);
    }
}
