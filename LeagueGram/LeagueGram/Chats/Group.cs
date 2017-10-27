using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueGram
{
    internal class Group : DefaultChat
    {
        public override Guid Id { get; }
        public override IMessage[] Messages { get; protected set; }
        public override IChatMember[] ChatMembers { get; set; }

        public override bool IsItPossibleToDeleteMessage(IUser chatMember, IMessage message)
        {
            return IsChatMember(chatMember) && DoesMessageExist(message) &&
                (FindChatMember(chatMember).Role == ChatRole.Admin || FindChatMember(chatMember).Role == ChatRole.Creator ||
                FindChatMember(chatMember).Id == FindMessage(message).SenderId);
        }

        public override bool IsItPossibleToEditMessage(IUser chatMember, IMessage message)
        {
            return IsChatMember(chatMember) && DoesMessageExist(message) && FindMessage(message).SenderId == FindChatMember(chatMember).Id;
        }

        public override bool IsItPossibleToEditRoleOfChatMember(IUser editor, IUser editingPerson)
        {
            return IsChatMember(editor) && FindChatMember(editor).Role == ChatRole.Creator &&
                IsChatMember(editingPerson);
        }

        public override bool IsItPossibleToInviteUser(IUser inviter, IUser invitedPerson)
        {
            return IsChatMember(inviter) && !IsChatMember(invitedPerson);
        }

        public override bool IsItPossibleToSendMessage(IUser chatMember)
        {
            return IsChatMember(chatMember);
        }

        public Group(IUser creator) {
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
