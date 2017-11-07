using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeagueLeo;
using System.Collections.Generic;
using System.Linq;
using LeagueLeo.Domain.Exception;

namespace LeagueLeoTests
{
    [TestClass]
    public class InJsonUsersWordRepositoryTester
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

        [TestMethod]
        public void InsertWordForNewUser_IsTranslationOfWordRight()
        {
            //Arrange
            InJsonUsersWordRepository usersWord = new InJsonUsersWordRepository();
            User user = new User("slava", Guid.NewGuid());
            Guid idForNew = Guid.NewGuid();
            Word word = new Word("new", "новый", idForNew);
            Word word2 = new Word("cola", "кола", Guid.NewGuid());
            IEnumerable<Word> words;
            List<Word> listOfWords;
            usersWord.AddWordForUser(user.Id, word);
            usersWord.AddWordForUser(user.Id, word2);
            string expected = "новый";
            //Act
            words = usersWord.LoadWordsForUser(user.Id);
            listOfWords = words.ToList();
            String result = listOfWords.Find(current => current.Id == idForNew).Translation;
            //Assert
            Assert.AreEqual(expected, result);
        }

        [ExpectedException(typeof(KeyNotFoundException)) ,TestMethod]
        public void AddPointsForNotExistingUser_IsItPossible()
        {
            InJsonUsersWordRepository usersWord = new InJsonUsersWordRepository();
            Guid userId = Guid.NewGuid();
            Word word = new Word("father", "папа", Guid.NewGuid());
            usersWord.AddPointsToWordForUser(userId, word);
        }

        [ExpectedException(typeof(WordNotFoundException)), TestMethod]
        public void AddPointsForNotExistingWord_IsItPossible()
        {
            InJsonUsersWordRepository usersWord = new InJsonUsersWordRepository();
            Guid userId = Guid.NewGuid();
            Word userWord = new Word("mother", "мама", Guid.NewGuid());
            usersWord.AddWordForUser(userId, userWord);
            Word word = new Word("father", "папа", Guid.NewGuid());
            usersWord.AddPointsToWordForUser(userId, word);
        }

        [ExpectedException(typeof(UserNotFoundException)), TestMethod]
        public void GetWordsForNotExistingUser_IsItPossible()
        {
            InJsonUsersWordRepository usersWord = new InJsonUsersWordRepository();
            Guid userId = Guid.NewGuid();
            usersWord.LoadWordsForUser(userId);
        }
    }
}
