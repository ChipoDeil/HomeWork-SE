using System.Collections.Generic;

namespace LeagueLeo.Facades
{
    public interface IGameSprint
    {
        Word GetRandomCombination();
        bool IsAnswerRight(string original, string translation, bool right);
        IEnumerable<Word> GetUnstudiedWords();
    }
}
