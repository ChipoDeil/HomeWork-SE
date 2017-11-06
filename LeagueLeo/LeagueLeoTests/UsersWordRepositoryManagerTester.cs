using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeagueLeo.Facades;
using LeagueLeo;
using System.Collections.Generic;
using System.Linq;

namespace LeagueLeoTests
{
    [TestClass]
    public class UsersWordRepositoryManagerTester
    {
        [ExpectedException(typeof(ArgumentException)), TestMethod]
        public void TryToGetWordsForNotExistingUser_IsItPossible()
        {
            InJsonUsersWordRepository usersWordRepository = new InJsonUsersWordRepository();
            InJsonUserRepository userRepository = new InJsonUserRepository();

            UsersWordRepositoryManager usersWord = new UsersWordRepositoryManager(usersWordRepository, userRepository);
            Guid randomId = Guid.NewGuid();
            usersWord.LoadWordsForUser(randomId);
        }

        [TestMethod]
        public void TryToGetWordsForExistingUser_IsItsLenghtRight()
        {
            //Arrange
            InJsonUsersWordRepository usersWordRepository = new InJsonUsersWordRepository();
            InJsonUserRepository userRepository = new InJsonUserRepository();

            UsersWordRepositoryManager usersWord = new UsersWordRepositoryManager(usersWordRepository, userRepository);
            UserManager userManager = new UserManager(userRepository);
            Guid userId = userManager.AddUser("egor");
            Word word = new Word("mother", "мама", Guid.NewGuid());
            usersWord.AddWordForUser(word, userId);
            word = new Word("father", "папа", Guid.NewGuid());
            usersWord.AddWordForUser(word, userId);
            int expected = 2;
            //Act
            List<Word> listOfWords = usersWord.LoadWordsForUser(userId).ToList();
            //Assert
            Assert.AreEqual(expected, listOfWords.Count);
        }

        [ExpectedException(typeof(ArgumentNullException)), TestMethod]
        public void TryToAddNullWord_IsItPossible()
        {
            InJsonUsersWordRepository usersWordRepository = new InJsonUsersWordRepository();
            InJsonUserRepository userRepository = new InJsonUserRepository();

            UsersWordRepositoryManager usersWord = new UsersWordRepositoryManager(usersWordRepository, 
                                                                                    userRepository);
            UserManager userManager = new UserManager(userRepository);
            Guid userId = userManager.AddUser("someone");
            Word word = null;
            usersWord.AddWordForUser(word, userId);
        }
    }
}
