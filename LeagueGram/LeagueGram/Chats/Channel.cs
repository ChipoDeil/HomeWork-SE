using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueGram
{
    internal class Channel : DefaultChat
    {
        public override Guid Id { get; }

        public override IMessage[] Messages { get; set; }

        public override IChatMember[] ChatMembers { get; set; }

        public override bool IsItPossibleToDeleteMessage(IUser chatMember, IMessage message)
        {
            return IsChatMember(chatMember) && FindChatMember(chatMember).Role == ChatRole.Creator && DoesMessageExist(message);
        }

        public override bool IsItPossibleToEditMessage(IUser chatMember, IMessage message)
        {
            return IsChatMember(chatMember) && FindChatMember(chatMember).Role == ChatRole.Creator && DoesMessageExist(message);
        }

        public override bool IsItPossibleToEditRoleOfChatMember(IUser editor, IUser editingPerson)
        {
            return false;
        }

        public override bool IsItPossibleToInviteUser(IUser inviter, IUser invitedPerson)
        {
            return IsChatMember(inviter) && !IsChatMember(invitedPerson);
        }

        public override bool IsItPossibleToSendMessage(IUser chatMember)
        {
            return IsChatMember(chatMember) && FindChatMember(chatMember).Role == ChatRole.Creator;
        }

        public Channel(IUser creator) {
            List<IChatMember> listOfChatMembers = new List<IChatMember>
            {
                new ChatMember(creator.Id, creator.NickName, ChatRole.Creator)
            };
            ChatMembers = listOfChatMembers.ToArray();
            Messages = new IMessage[0];
            Id = Guid.NewGuid();
        }
    }
}
