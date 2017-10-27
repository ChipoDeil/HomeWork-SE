using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeagueGram;


namespace LeagueGramTester
{
    [TestClass]
    public class LeagueGramTester
    {
        [TestMethod]
        public void TryToCreateUser_IsItCreated()
        {
            //Arrange
            LeagueGramHead leagueGram = new LeagueGramHead();
            int expected = 1;
            //Act
            leagueGram.RegisterUser("petya");
            //Assert
            Assert.AreEqual(expected, leagueGram.userManager.Users.Length);
        }

        [ExpectedException(typeof(Exception)),TestMethod]
        public void TryToCreateChatByNotExistingUser_IsItPossible()
        {
            LeagueGramHead leagueGram = new LeagueGramHead();
            Guid randomId = Guid.NewGuid();
            leagueGram.CreateChannel(randomId);
        }

        [TestMethod]
        public void TryToCreateChatByExistingUser_IsItCreated()
        {
            //Arrange
            LeagueGramHead leagueGram = new LeagueGramHead();
            Guid id  = leagueGram.RegisterUser("petya");
            int expected = 1;
            //Act
            leagueGram.CreateChannel(id);
            //Assert
            Assert.AreEqual(expected, leagueGram.chatFactory.ListOfCreatedChats.Count);
        }

        [TestMethod]
        public void TryToCreateChatByExistingUser_IsItCreatedForUser()
        {
            //Arrange
            LeagueGramHead leagueGram = new LeagueGramHead();
            Guid id = leagueGram.RegisterUser("petya");
            int expected = 1;
            //Act
            leagueGram.CreateChannel(id);
            //Assert
            Assert.AreEqual(expected, leagueGram.userManager.Users[0].Chats.Length);
        }

        [ExpectedException(typeof(Exception)), TestMethod]
        public void TryToInviteToNotExistingChat_IsItPossible()
        {
            LeagueGramHead leagueGram = new LeagueGramHead();

            Guid user1Id = leagueGram.RegisterUser("petya");
            Guid user2Id = leagueGram.RegisterUser("volodya");

            Guid chatId = Guid.NewGuid();

            leagueGram.InviteUserToChat(user1Id, user2Id, chatId);
        }

        [TestMethod]
        public void TryToInviteToChat_IsChatAddedForInvitedUser()
        {
            //Arrange
            LeagueGramHead leagueGram = new LeagueGramHead();

            Guid user1Id = leagueGram.RegisterUser("petya");
            Guid user2Id = leagueGram.RegisterUser("volodya");

            Guid chatId = leagueGram.CreateChannel(user1Id);
            int expected = 1;
            //Act
            leagueGram.InviteUserToChat(user1Id, user2Id, chatId);
            //Assert
            Assert.AreEqual(expected, leagueGram.userManager.GetUserById(user2Id).Chats.Length);
        }

        [ExpectedException(typeof(Exception)), TestMethod]
        public void TryToInviteToChatByNotChatMember_IsItPossible()
        {
            LeagueGramHead leagueGram = new LeagueGramHead();

            Guid user1Id = leagueGram.RegisterUser("petya");
            Guid user2Id = leagueGram.RegisterUser("volodya");
            Guid user3Id = leagueGram.RegisterUser("volodya");

            Guid chatId = leagueGram.CreateChannel(user3Id);
            leagueGram.InviteUserToChat(user1Id, user2Id, chatId);
        }

        [ExpectedException(typeof(Exception)), TestMethod]
        public void TryToEditRoleByNotAChatMember_IsItPossible()
        {
            LeagueGramHead leagueGram = new LeagueGramHead();

            Guid user1Id = leagueGram.RegisterUser("petya");
            Guid user2Id = leagueGram.RegisterUser("volodya");
            Guid user3Id = leagueGram.RegisterUser("volodya");

            Guid chatId = leagueGram.CreateChannel(user3Id);
            leagueGram.EditRoleOfChatMember(user1Id, user3Id, chatId, ChatRole.Admin);
        }

        [ExpectedException(typeof(Exception)), TestMethod]
        public void TryToSendMessageByNotChatMember_IsItPossible()
        {
            LeagueGramHead leagueGram = new LeagueGramHead();

            Guid user1Id = leagueGram.RegisterUser("petya");
            Guid user2Id = leagueGram.RegisterUser("volodya");

            Guid chatId = leagueGram.CreateGroup(user1Id);
            leagueGram.SendMessage(user2Id, chatId, "lol");
        }
    }
}
