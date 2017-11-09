using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeagueLeo;
using LeagueLeo.Facades;
using LeagueLeo.Domain.Exception;

namespace LeagueLeoTests
{
    [TestClass]
    public class GameSprintTester
    {
        [TestMethod]
        public void TryToStartSprintWithAllRightСonditions_CanGetRandomWordFromUserVocabulary()
        {
            //Arrange
            InJsonUsersWordRepository usersWordRepository = new InJsonUsersWordRepository();
            InJsonUserRepository userRepository = new InJsonUserRepository();

            UsersWordRepositoryManager usersWord = new UsersWordRepositoryManager(usersWordRepository, userRepository);
            UserManager userManager = new UserManager(userRepository);

            Guid userId = userManager.AddUser("someone");
            Word word1 = new Word("father", "папа", Guid.NewGuid());
            usersWord.AddWordForUser(word1, userId);
            Word word2 = new Word("mother", "мама", Guid.NewGuid());
            usersWord.AddWordForUser(word2, userId);
            Word word3 = new Word("child", "ребенок", Guid.NewGuid());
            usersWord.AddWordForUser(word3, userId);
            GameSprint gameSprint = new GameSprint(usersWordRepository, userRepository, userId);
            //Act
            Word word = gameSprint.GetRandomWord();
            bool result = word.Original == word1.Original ||
                        word.Original == word2.Original ||
                        word.Original == word3.Original;
            //Assert
            Assert.IsTrue(result);
        }

        [ExpectedException(typeof(NotEnoughUnstudiedWordsToStartSprintException)), TestMethod]
        public void TryToStartSprintWithOnlyTwoWords_IsItPossible()
        {
            InJsonUsersWordRepository usersWordRepository = new InJsonUsersWordRepository();
            InJsonUserRepository userRepository = new InJsonUserRepository();

            UsersWordRepositoryManager usersWord = new UsersWordRepositoryManager(usersWordRepository, userRepository);
            UserManager userManager = new UserManager(userRepository);

            Guid userId = userManager.AddUser("someone");
            Word word1 = new Word("father", "папа", Guid.NewGuid());
            usersWord.AddWordForUser(word1, userId);
            Word word2 = new Word("mother", "мама", Guid.NewGuid());
            usersWord.AddWordForUser(word2, userId);
            GameSprint gameSprint = new GameSprint(usersWordRepository, userRepository, userId);

        }

        [ExpectedException(typeof(NotEnoughUnstudiedWordsToStartSprintException)), TestMethod]
        public void TryToStartSprintWithOnlyTwoUnstudiedWords_IsItPossible()
        {
            InJsonUsersWordRepository usersWordRepository = new InJsonUsersWordRepository();
            InJsonUserRepository userRepository = new InJsonUserRepository();

            UsersWordRepositoryManager usersWord = new UsersWordRepositoryManager(usersWordRepository, userRepository);
            UserManager userManager = new UserManager(userRepository);

            Guid userId = userManager.AddUser("someone");
            Word word1 = new Word("father", "папа", Guid.NewGuid());
            usersWord.AddWordForUser(word1, userId);
            Word word2 = new Word("mother", "мама", Guid.NewGuid());
            usersWord.AddWordForUser(word2, userId);
            Word word3 = new Word("mother", "мама", Guid.NewGuid());
            Guid idWord3 = usersWord.AddWordForUser(word3, userId);
            word3 = new Word("mother", "мама", idWord3);
            usersWordRepository.AddPointsToWordForUser(userId, word3);
            usersWordRepository.AddPointsToWordForUser(userId, word3);
            usersWordRepository.AddPointsToWordForUser(userId, word3);

            GameSprint gameSprint = new GameSprint(usersWordRepository, userRepository, userId);
        }
    }
}
