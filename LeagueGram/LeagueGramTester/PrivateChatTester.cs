using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeagueGram;
namespace LeagueGramTester
{
    [TestClass]
    public class PrivateChatTester
    {
        [TestMethod]
        public void SendMessage_HasMessageAdded()
        {
            //Arrange
            User person1 = new User(Guid.NewGuid(), "petya");
            User person2 = new User(Guid.NewGuid(), "katya");

            PrivateChat privateChat = new PrivateChat(person1, person2);
            string expected = "123";
            //Act
            privateChat.SendMessage(person1, "123");
            IMessage[] messages = privateChat.Messages;
            //Assert
            Assert.AreEqual(expected, messages[0].Text);
        }

        [TestMethod]
        public void SendTwoMessages_HaveMessagesAdded()
        {
            //Arrange
            User person1 = new User(Guid.NewGuid(), "petya");
            User person2 = new User(Guid.NewGuid(), "katya");

            PrivateChat privateChat = new PrivateChat(person1, person2);
            string expected = "123";
            //Act
            privateChat.SendMessage(person1, "321");
            privateChat.SendMessage(person2, "123");
            IMessage[] messages = privateChat.Messages;
            //Assert
            Assert.AreEqual(expected, messages[1].Text);
        }

        [TestMethod]
        public void TryToDeleteNotOwnMessage_IsItPossible()
        {
            //Arrange
            User person1 = new User(Guid.NewGuid(), "petya");
            User person2 = new User(Guid.NewGuid(), "katya");

            PrivateChat privateChat = new PrivateChat(person1, person2);
            //Act
            privateChat.SendMessage(person1, "321");
            privateChat.SendMessage(person2, "123");
            IMessage[] messages = privateChat.Messages;
            bool result = privateChat.IsItPossibleToDeleteMessage(person1, messages[1]);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryToDeleteOwnMessage_IsItPossible()
        {
            //Arrange
            User person1 = new User(Guid.NewGuid(), "petya");
            User person2 = new User(Guid.NewGuid(), "katya");

            PrivateChat privateChat = new PrivateChat(person1, person2);
            //Act
            privateChat.SendMessage(person1, "321");
            privateChat.SendMessage(person2, "123");
            IMessage[] messages = privateChat.Messages;
            bool result = privateChat.IsItPossibleToDeleteMessage(person1, messages[0]);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TryToDeleteOwnMessage_IsItDeleted()
        {
            //Arrange
            User person1 = new User(Guid.NewGuid(), "petya");
            User person2 = new User(Guid.NewGuid(), "katya");

            PrivateChat privateChat = new PrivateChat(person1, person2);
            int expected = 1;
            //Act
            privateChat.SendMessage(person1, "321");
            privateChat.SendMessage(person2, "123");
            IMessage[] messages = privateChat.Messages;
            privateChat.DeleteMessage(person1, messages[0]);
            messages = privateChat.Messages;
            //Assert
            Assert.AreEqual(expected, messages.Length);
        }

        [TestMethod]
        public void TryToEditOwnMessage_IsItPossible()
        {
            //Arrange
            User person1 = new User(Guid.NewGuid(), "petya");
            User person2 = new User(Guid.NewGuid(), "katya");

            PrivateChat privateChat = new PrivateChat(person1, person2);
            //Act
            privateChat.SendMessage(person1, "321");
            privateChat.SendMessage(person2, "123");
            IMessage[] messages = privateChat.Messages;
            bool result = privateChat.IsItPossibleToEditMessage(person1, messages[0]);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TryToEditNotOwnMessage_IsItPossible()
        {
            //Arrange
            User person1 = new User(Guid.NewGuid(), "petya");
            User person2 = new User(Guid.NewGuid(), "katya");

            PrivateChat privateChat = new PrivateChat(person1, person2);
            //Act
            privateChat.SendMessage(person1, "321");
            privateChat.SendMessage(person2, "123");
            IMessage[] messages = privateChat.Messages;
            bool result = privateChat.IsItPossibleToEditMessage(person1, messages[1]);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryToEditOwnMessage_IsItEdited()
        {
            //Arrange
            User person1 = new User(Guid.NewGuid(), "petya");
            User person2 = new User(Guid.NewGuid(), "katya");

            PrivateChat privateChat = new PrivateChat(person1, person2);
            string expected = "asd";
            //Act
            privateChat.SendMessage(person1, "321");
            privateChat.SendMessage(person2, "123");
            IMessage[] messages = privateChat.Messages;
            privateChat.EditMessage(person1, messages[0], expected);
            messages = privateChat.Messages;
            //Assert
            Assert.AreEqual(expected, messages[0].Text);
        }

    }
}
