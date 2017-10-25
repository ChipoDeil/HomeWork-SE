using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueGram
{
    internal abstract class DefaultChat : IChat
    {
        public abstract Guid Id { get; }
        public abstract IMessage[] Messages { get; set; }
        public abstract IChatMember[] ChatMembers { get; set; }

        public abstract void DeleteMessage(IUser chatMember, IMessage message);
        public abstract void EditMessage(IUser chatMember, IMessage message, string newMessage);
        public abstract void EditRoleOfChatMember(IUser editor, IUser editingPerson, ChatRole newRole);
        public abstract void InviteUser(IUser inviter, IUser invitedPerson);
        public bool IsChatMember(IUser chatMember) {
            foreach (IChatMember locChatMember in ChatMembers) {
                if (locChatMember.Id == chatMember.Id)
                    return true;
            }
            return false;
        }
        public abstract bool IsItPossibleToSendMessage(IUser chatMember);
        public abstract void SendMessage(IUser chatMember, string Message);

        public IChatMember FindChatMember(IUser chatMember) {

            foreach (IChatMember locChatMember in ChatMembers)
            {
                if (locChatMember.Id == chatMember.Id)
                {
                    return locChatMember;
                }
            }
            return null;
        }
    }
}
