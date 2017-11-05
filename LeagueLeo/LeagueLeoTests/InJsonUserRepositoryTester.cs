using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeagueLeo;
using System.Collections.Generic;

namespace LeagueLeoTests
{
    [TestClass]
    public class InJsonUserRepositoryTester
    {
        [TestMethod]
        public void InsertTwoUsers_IsItPossibleToGetSecond()
        {
            //Arrange
            InJsonUserRepository rep = new InJsonUserRepository();
            User user = new User("123", Guid.NewGuid());
            User user2 = new User("123", Guid.NewGuid());
            List<User> listOfUsers = new List<User>();
            listOfUsers.Add(user);
            listOfUsers.Add(user2);
            User expected = user2;
            //Act
            rep.SaveUser(user);
            rep.SaveUser(user2);
            User result = rep.LoadUser(user2.Id);
            //Assert
            Assert.AreEqual(expected.Id, result.Id);
        }

        //боже как я заебался
    }
}
