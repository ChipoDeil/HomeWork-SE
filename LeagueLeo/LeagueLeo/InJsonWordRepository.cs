using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueLeo
{
    public class InJsonWordRepository : IWordRepository
    {
        List<Word> listOfWords = new List<Word>();
        DealWithFile dealWithFile = new DealWithFile();
        string pathFile = Properties.currentDirectory;
        string wordFile = Properties.wordFile; 

        public Word LoadWord(Guid wordId)
        {
            return listOfWords.Find(current => current.Id == wordId);
        }

        public void SaveWord(Word word)
        {
            listOfWords.Add(word);
            dealWithFile.SaveToFile(pathFile, wordFile, listOfWords);

        }

        public InJsonWordRepository() {
            if (dealWithFile.ReadFromFile<List<Word>>(pathFile, wordFile) != null)
                listOfWords = dealWithFile.ReadFromFile<List<Word>>(pathFile, wordFile);
        }
    }
}
