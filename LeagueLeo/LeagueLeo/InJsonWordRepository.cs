using System;
using System.Collections.Generic;

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
            Word word = listOfWords.Find(current => current.Id == wordId);
            if (word == null)
                throw new ArgumentException("word not found");
            return word;
        }

        public void SaveWord(Word word)
        {
            if (word == null)
                throw new ArgumentNullException();
            listOfWords.Add(word);
            dealWithFile.SaveToFile(pathFile, wordFile, listOfWords);

        }

        public IEnumerable<Word> LoadAllWords()
        {
            return listOfWords.ToArray();
        }

        public InJsonWordRepository() {
            if (dealWithFile.ReadFromFile<List<Word>>(pathFile, wordFile) != null)
                listOfWords = dealWithFile.ReadFromFile<List<Word>>(pathFile, wordFile);
        }
    }
}
