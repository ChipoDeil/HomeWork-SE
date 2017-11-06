using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeagueLeo;
using LeagueLeo.Facades;

namespace LeagueLeoTests
{
    [TestClass]
    public class UserManagerTester
    {
        [ExpectedException(typeof(ArgumentNullException)),TestMethod]
        public void TryToAddUserWithNullNickName_IsItPossible()
        {
            InJsonUserRepository userRepository = new InJsonUserRepository();
            UserManager userManager = new UserManager(userRepository);
            string nickname = null;
            userManager.AddUser(nickname);
        }

        [TestMethod]
        public void TryToAddUser_IsUserNickNameRight()
        {
            //Arrange
            InJsonUserRepository userRepository = new InJsonUserRepository();
            UserManager userManager = new UserManager(userRepository);
            string expected = "lida";
            //Act
            Guid userId = userManager.AddUser(expected);
            User user = userRepository.LoadUser(userId);
            //Assert
            Assert.AreEqual(expected, user.NickName);
        }

        [TestMethod]
        public void TryToAddTwoUser_IsUsersNickNamesRight()
        {
            //Arrange
            InJsonUserRepository userRepository = new InJsonUserRepository();
            UserManager userManager = new UserManager(userRepository);
            string userNickName1 = "lida";
            string userNickName2 = "vasya";
            string expected = userNickName1 + userNickName2;
            //Act
            Guid userId1 = userManager.AddUser(userNickName1);
            Guid userId2 = userManager.AddUser(userNickName2);
            User user1 = userRepository.LoadUser(userId1);
            User user2 = userRepository.LoadUser(userId2);
            //Assert
            Assert.AreEqual(expected, user1.NickName+user2.NickName);
        }
    }
}
