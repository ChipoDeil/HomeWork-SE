using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeagueLeo;
using System.Linq;
using System.Collections.Generic;

namespace LeagueLeoTests
{
    [TestClass]
    public class InJsonWordRepositoryTester
    {
        [TestMethod]
        public void TryToLoadWordsFromFile_IsLengthRight()
        {
            //Arrange
            InJsonWordRepository wordRepository = new InJsonWordRepository();
            List<Word> listOfWords = wordRepository.LoadAllWords().ToList();
            int expected = 10;
            //Act
            int count = listOfWords.Count;
            //Assert
            Assert.AreEqual(expected, count);
        }

        [ExpectedException(typeof(ArgumentException)) ,TestMethod]
        public void TryToLoadFakeWordFromFile_IsItPossible()
        {
            InJsonWordRepository wordRepository = new InJsonWordRepository();
            wordRepository.LoadWord(Guid.NewGuid());
        }

        [TestMethod]
        public void TryToLoadRealWordFromFile_IsItRight()
        {
            //Arrange
            InJsonWordRepository wordRepository = new InJsonWordRepository();
            List<Word> listOfWords = wordRepository.LoadAllWords().ToList();
            Guid firstId = listOfWords.First().Id;
            string expected = listOfWords.First().Original;
            //Act
            Word word = wordRepository.LoadWord(firstId);
            //Assert
            Assert.AreEqual(expected, word.Original);
        }

        [ExpectedException(typeof(ArgumentNullException)), TestMethod]
        public void TryToSaveNullWord_IsItPossible()
        {
            InJsonWordRepository wordRepository = new InJsonWordRepository();
            Word word = null;
            wordRepository.SaveWord(word);
        }
    }
}
