using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeagueLeo;
using System.Collections.Generic;
using System.Linq;
using LeagueLeo.Domain.Exception;

namespace LeagueLeoTests
{
    [TestClass]
    public class GlobalDictionaryManagerTester
    {
        [ExpectedException(typeof(ArgumentNullException)) ,TestMethod]
        public void TryToCreateFacadeWithNullArument_IsItPossible()
        {
            InJsonWordRepository wordRepository = null;
            GlobalDictionaryManager globalDictionary = new GlobalDictionaryManager(wordRepository);
        }

        [TestMethod]
        public void AddWordToGlobalDictionary_HasItAdded()
        {
            //Arrange
            InJsonWordRepository wordRepository = new InJsonWordRepository();
            GlobalDictionaryManager globalDictionary = new GlobalDictionaryManager(wordRepository);
            List<Word> listOfWords = globalDictionary.GetAllWords().ToList();
            int expected = listOfWords.Count + 1;
            Word newWord = new Word("original", "оригинал", Guid.NewGuid());
            //Act
            globalDictionary.AddWord(newWord);
            listOfWords = globalDictionary.GetAllWords().ToList();
            int result = listOfWords.Count;
            //Assert
            Assert.AreEqual(expected, result);
        }

        [ExpectedException(typeof(ArgumentNullException)) ,TestMethod]
        public void AddWordNullWord_IsItPossible()
        {
            InJsonWordRepository wordRepository = new InJsonWordRepository();
            GlobalDictionaryManager globalDictionary = new GlobalDictionaryManager(wordRepository);
            Word newWord = null;
            globalDictionary.AddWord(newWord);
        }

        [ExpectedException(typeof(WordNotFoundException)), TestMethod]
        public void TryToLoadRandomWord_IsItPossible()
        {
            InJsonWordRepository wordRepository = new InJsonWordRepository();
            GlobalDictionaryManager globalDictionary = new GlobalDictionaryManager(wordRepository);
            Guid wordId = Guid.NewGuid();
            globalDictionary.GetWord(wordId);
        }
    }
}
