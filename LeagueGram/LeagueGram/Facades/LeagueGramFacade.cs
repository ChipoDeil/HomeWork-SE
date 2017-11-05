using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueGram
{
    public class LeagueGramFacade
    {
        LeagueGramHead leagueGram;
        public Guid RegisterUser() {
            return Guid.NewGuid();
        }

        public void SendMessage(Guid userId, Guid chatId, string message) {
            leagueGram.SendMessage(userId, chatId, message);
        }

        public void DeleteMessage(Guid userId, Guid chatId, Guid messageId) {
            leagueGram.DeleteMessage(userId, chatId, messageId);
        }

        public void EditMessage(Guid userId, Guid chatId, Guid messageId, string newMessage) {
            leagueGram.EditMessage(userId, chatId, messageId, newMessage);
        }

        public Guid CreatePrivateChat(Guid userId, Guid invitedPerson) {
            return leagueGram.CreatePrivateChat(userId, invitedPerson);
        }

        public Guid CreateGroup(Guid userId) {
            return leagueGram.CreateGroup(userId);
        }

        public Guid CreateChannel(Guid userId) {
            return leagueGram.CreateChannel(userId);
        }

        public void InviteUserToChat(Guid inviterId, Guid invitedPersonId, Guid chatId) {
            leagueGram.InviteUserToChat(inviterId, invitedPersonId, chatId); 
        }

        public void EditRoleOfChatMember(Guid changer, Guid target, Guid chatId, ChatRole newRole) {
            leagueGram.EditRoleOfChatMember(changer, target, chatId, newRole);
        }

        public IEnumerable<IChat> GetChatsForUser(Guid userId)
        {
            return leagueGram.GetChatsForUser(userId);
        }

        public IEnumerable<IMessage> GetMessagesForUser(Guid userId, Guid chatId)
        {
            return leagueGram.GetMessagesForUser(userId, chatId);
        }

        public LeagueGramFacade() {
            leagueGram = new LeagueGramHead();
        }
    }
}
