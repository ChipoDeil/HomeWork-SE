using System;

namespace LeagueGram
{
    public interface IChat
    {
        Guid Id { get; }
        IMessage[] Messages { get; set; }
        IChatMember ChatMembers { get; }

        bool IsItPossibleToSendMessage(IChatMember chatMember);

        void SendMessage(IChatMember chatMember, string Message);

        void EditMessage(IChatMember chatMember, IMessage message, string newMessage);

        void DeleteMessage(IChatMember chatMember, IMessage message);

        void InviteUser(IChatMember inviter, IChatMember invitedPerson);

        void EditRoleOfChatMember(IChatMember editor, IChatMember editingPerson, ChatRole newRole);

    }
}
