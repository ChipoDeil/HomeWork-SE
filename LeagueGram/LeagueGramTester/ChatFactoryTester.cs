using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeagueGram;

namespace LeagueGramTester
{
    [TestClass]
    public class ChatFactoryTester
    {
        [TestMethod]
        public void TryToCreateNewChat_HasChatAddedToList()
        { //Arrange
            User person1 = new User(Guid.NewGuid(), "petya");
            User person2 = new User(Guid.NewGuid(), "katya");
            ChatFactory chatFactory = new ChatFactory();
            int expected = 1;
            //Act
            chatFactory.CreatePrivateChat(person1, person2);
            //Assert
            Assert.AreEqual(expected, chatFactory.ListOfCreatedChats.Count);
        }
    }
}
