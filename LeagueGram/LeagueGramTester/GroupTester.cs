using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeagueGram;

namespace LeagueGramTester
{
    [TestClass]
    public class GroupTester
    {
        [TestMethod]
        public void TryToSendMessageByChatMember_IsItPossible()
        {
            //Arrange
            User person1 = new User(Guid.NewGuid(), "petya");
            User person2 = new User(Guid.NewGuid(), "katya");

            Group group = new Group(person1);
            group.InviteUser(person1, person2);
            //Act
            bool result = group.IsItPossibleToSendMessage(person2);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TryToSendMessageNotByChatMember_IsItPossible()
        {
            //Arrange
            User person1 = new User(Guid.NewGuid(), "petya");
            User person2 = new User(Guid.NewGuid(), "katya");

            Group group = new Group(person1);
            //Act
            bool result = group.IsItPossibleToSendMessage(person2);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryToSendChangeChatMemberStatusByCreator_IsItPossible()
        {
            //Arrange
            User person1 = new User(Guid.NewGuid(), "petya");
            User person2 = new User(Guid.NewGuid(), "katya");

            Group group = new Group(person1);
            group.InviteUser(person1, person2);
            //Act
            bool result = group.IsItPossibleToEditRoleOfChatMember(person1, person2);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TryToSendChangeNotChatMemberStatusByCreator_IsItPossible()
        {
            //Arrange
            User person1 = new User(Guid.NewGuid(), "petya");
            User person2 = new User(Guid.NewGuid(), "katya");

            Group group = new Group(person1);
            //Act
            bool result = group.IsItPossibleToEditRoleOfChatMember(person1, person2);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryToSendChangeChatMemberStatusNotByCreator_IsItPossible()
        {
            //Arrange
            User person1 = new User(Guid.NewGuid(), "petya");
            User person2 = new User(Guid.NewGuid(), "katya");

            Group group = new Group(person1);
            group.InviteUser(person1, person2);
            //Act
            bool result = group.IsItPossibleToEditRoleOfChatMember(person2, person1);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryToDeleteNotOwnMessageByAdmin_IsItPossible()
        {
            //Arrange
            User person1 = new User(Guid.NewGuid(), "petya");
            User person2 = new User(Guid.NewGuid(), "katya");
            User person3 = new User(Guid.NewGuid(), "ivan");


            Group group = new Group(person1);
            group.InviteUser(person1, person2);
            group.InviteUser(person2, person3);
            group.EditRoleOfChatMember(person1, person2, ChatRole.Admin);
            group.SendMessage(person3, "kek");
            IMessage[] messages = group.Messages;
            //Act
            bool result = group.IsItPossibleToDeleteMessage(person2, messages[0]);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TryToDeleteNotOwnMessageNotByAdmin_IsItPossible()
        {
            //Arrange
            User person1 = new User(Guid.NewGuid(), "petya");
            User person2 = new User(Guid.NewGuid(), "katya");
            User person3 = new User(Guid.NewGuid(), "ivan");


            Group group = new Group(person1);
            group.InviteUser(person1, person2);
            group.InviteUser(person2, person3);
            group.SendMessage(person3, "kek");
            IMessage[] messages = group.Messages;
            //Act
            bool result = group.IsItPossibleToDeleteMessage(person2, messages[0]);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryToAddMessage_IsMessageAdded()
        {
            //Arrange
            User person1 = new User(Guid.NewGuid(), "petya");
            User person2 = new User(Guid.NewGuid(), "katya");
            User person3 = new User(Guid.NewGuid(), "ivan");


            Group group = new Group(person1);
            group.InviteUser(person1, person2);
            group.InviteUser(person2, person3);
            int expected = 1;
            //Act
            group.SendMessage(person3, "kek");
            IMessage[] messages = group.Messages;
            //Assert
            Assert.AreEqual(expected, messages.Length);
        }

        [TestMethod]
        public void TryToAddMessage_IsTextOfMessageCorrect()
        {
            //Arrange
            User person1 = new User(Guid.NewGuid(), "petya");
            User person2 = new User(Guid.NewGuid(), "katya");
            User person3 = new User(Guid.NewGuid(), "ivan");


            Group group = new Group(person1);
            group.InviteUser(person1, person2);
            group.InviteUser(person2, person3);
            string expected = "kek";
            //Act
            group.SendMessage(person3, expected);
            IMessage[] messages = group.Messages;
            //Assert
            Assert.AreEqual(expected, messages[0].Text);
        }

        [TestMethod]
        public void TryToEditChatRoleOfChatMemberByAdmin_IsItPossible()
        {
            //Arrange
            User person1 = new User(Guid.NewGuid(), "petya");
            User person2 = new User(Guid.NewGuid(), "katya");


            Group group = new Group(person1);
            group.InviteUser(person1, person2);
            group.EditRoleOfChatMember(person1, person2, ChatRole.Admin);
            //Act
            bool result = group.IsItPossibleToEditRoleOfChatMember(person2, person1);
            //Assert
            Assert.IsFalse(result);
        }

    }
}
