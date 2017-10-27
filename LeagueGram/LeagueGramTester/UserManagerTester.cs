using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeagueGram;

namespace LeagueGramTester
{
    [TestClass]
    public class UserManagerTester
    {
        [TestMethod]
        public void TryToRegister_HasUserAdded()
        {
            //Arrange
            UserManager userManager = new UserManager();
            int expected = 1;
            //Act
            userManager.RegisterUser("kolya");
            //Assert
            Assert.AreEqual(expected, userManager.Users.Length);
        }

        [ExpectedException(typeof(Exception)) ,TestMethod]
        public void TryToGetByIdNotExistingUser_IsItPossible()
        {
            UserManager userManager = new UserManager();
            userManager.GetUserById(Guid.NewGuid());
        }

        [TestMethod]
        public void RegisteredUser_IsItExist()
        {
            //Arrange
            UserManager userManager = new UserManager();
            Guid id = userManager.RegisterUser("petya");
            //Act
            bool result = userManager.DoesUserExist(id);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TryToGetRegisteredUserById_IsItsNickNameRight()
        {
            //Arrange
            UserManager userManager = new UserManager();
            Guid id = userManager.RegisterUser("petya");
            string expected = "petya";
            //Act
            IUser user = userManager.GetUserById(id);
            //Assert
            Assert.AreEqual(expected, user.NickName);
        }

        [TestMethod]
        public void TryToJoinChatByExistingUser_IsChatAdded()
        {
            //Arrange
            UserManager userManager = new UserManager();
            Guid id = userManager.RegisterUser("petya");
            IChat chat = new Group(userManager.GetUserById(id));
            int expected = 1;
            //Act
            userManager.JoinChat(id, chat);
            //Assert
            Assert.AreEqual(expected, userManager.GetUserById(id).Chats.Length);
        }

    }
}
