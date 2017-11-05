using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeagueLeo;
using System.Collections.Generic;
using System.Linq;

namespace LeagueLeoTests
{
    [TestClass]
    public class InJsonUsersWordrepositoryTester
    {
        [TestMethod]
        public void InsertTwoWordsForNewUser_IsLengthOfListOfWordsRight()
        {
            //Arrange
            InJsonUsersWordRepository usersWord = new InJsonUsersWordRepository();
            User user = new User("slava", Guid.NewGuid());
            Word word = new Word("new", "новый", Guid.NewGuid());
            Word word2 = new Word("cola", "кола", Guid.NewGuid());
            IEnumerable<Word> words;
            List<Word> listOfWords;
            usersWord.AddWordForUser(user.Id, word);
            usersWord.AddWordForUser(user.Id, word2);
            int expected = 2;
            //Act
            words = usersWord.LoadWordsForUser(user.Id);
            listOfWords = words.ToList();
            //Assert
            Assert.AreEqual(expected, listOfWords.Count);
        }
    }
}
