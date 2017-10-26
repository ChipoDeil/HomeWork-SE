using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeagueGram;

namespace LeagueGramTester
{
    [TestClass]
    public class ChannelTester
    {
        [TestMethod]
        public void TryToDeleteMessageNotByCreator_IsItPossible()
        {
            //Arrange
            User person1 = new User(Guid.NewGuid(), "petya");
            User person2 = new User(Guid.NewGuid(), "katya");

            Channel channel = new Channel(person1);

            channel.InviteUser(person1, person2);
            //Act
            channel.SendMessage(person1, "321");
            IMessage[] messages = channel.Messages;
            bool result = channel.IsItPossibleToDeleteMessage(person2, messages[0]);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryToDeleteMessageByCreator_IsItPossible()
        {
            //Arrange
            User person1 = new User(Guid.NewGuid(), "petya");
            User person2 = new User(Guid.NewGuid(), "katya");

            Channel channel = new Channel(person1);

            channel.InviteUser(person1, person2);
            //Act
            channel.SendMessage(person1, "321");
            IMessage[] messages = channel.Messages;
            bool result = channel.IsItPossibleToDeleteMessage(person1, messages[0]);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TryToSendMessageNotByCreator_IsItPossible()
        {
            //Arrange
            User person1 = new User(Guid.NewGuid(), "petya");
            User person2 = new User(Guid.NewGuid(), "katya");

            Channel channel = new Channel(person1);

            channel.InviteUser(person1, person2);
            //Act
            bool result = channel.IsItPossibleToSendMessage(person2);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryToSendMessageByCreator_IsItPossible()
        {
            //Arrange
            User person1 = new User(Guid.NewGuid(), "petya");
            User person2 = new User(Guid.NewGuid(), "katya");

            Channel channel = new Channel(person1);
            //Act
            bool result = channel.IsItPossibleToSendMessage(person1);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TryToInviteUserWhoIsNotAChatMember_IsItPossible()
        {
            //Arrange
            User person1 = new User(Guid.NewGuid(), "petya");
            User person2 = new User(Guid.NewGuid(), "katya");

            Channel channel = new Channel(person1);
            //Act
            bool result = channel.IsItPossibleToInviteUser(person1, person2);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TryToInviteUserWhoIsAChatMember_IsItPossible()
        {
            //Arrange
            User person1 = new User(Guid.NewGuid(), "petya");
            User person2 = new User(Guid.NewGuid(), "katya");

            Channel channel = new Channel(person1);

            channel.InviteUser(person1, person2);
            //Act
            bool result = channel.IsItPossibleToInviteUser(person1, person2);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryToInviteUserWhoIsNotAChatMember_HasUserAdded()
        {
            //Arrange
            User person1 = new User(Guid.NewGuid(), "petya");
            User person2 = new User(Guid.NewGuid(), "katya");

            Channel channel = new Channel(person1);

            int expected = 2;
            //Act
            channel.InviteUser(person1, person2);
            IChatMember[] members = channel.ChatMembers;
            //Assert
            Assert.AreEqual(expected, members.Length);
        }

        [TestMethod]
        public void TryToSendMessageByCreator_HasMessageAdded()
        {
            //Arrange
            User person1 = new User(Guid.NewGuid(), "petya");
            User person2 = new User(Guid.NewGuid(), "katya");

            Channel channel = new Channel(person1);

            int expected = 1;
            //Act
            channel.SendMessage(person1, "lol");
            IMessage[] messages = channel.Messages;
            //Assert
            Assert.AreEqual(expected, messages.Length);
        }

    }
}
