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
        public void TestMethod1()
        {
            //Arrange
            InJsonUserRepository rep = new InJsonUserRepository();
            User user = new User("asda", Guid.NewGuid());
            User user1 = new User("asdasds", Guid.NewGuid());
            List<IUser> listOfUsers = new List<IUser>();
            listOfUsers.Add(user);
            listOfUsers.Add(user1);
            IUser expected = user1;
            //Act
            rep.SaveUser(user);
            rep.SaveUser(user1);
            IUser result = rep.LoadUser(user1.Id);
            //Assert
            Assert.AreEqual(expected.Id, result.Id);
        }
    }
}
