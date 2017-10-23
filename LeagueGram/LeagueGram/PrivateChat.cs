using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueGram
{
    class PrivateChat : IChat
    {
        public Guid Id;

        public IMessage[] Messages { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IChatMember ChatMembers => throw new NotImplementedException();

        public void DeleteMessage(IChatMember chatMember, IMessage message)
        {
            throw new NotImplementedException();
        }

        public void EditMessage(IChatMember chatMember, IMessage message, string newMessage)
        {
            throw new NotImplementedException();
        }

        public void EditRoleOfChatMember(IChatMember editor, IChatMember editingPerson, ChatRole newRole)
        {
            throw new NotImplementedException();
        }

        public void InviteUser(IChatMember inviter, IChatMember invitedPerson)
        {
            throw new NotImplementedException();
        }

        public bool IsItPossibleToSendMessage(IChatMember chatMember)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(IChatMember chatMember, string Message)
        {
            throw new NotImplementedException();
        }
    }
}
