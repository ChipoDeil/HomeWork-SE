using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("LeagueGramTester")]
namespace LeagueGram
{
    internal class PrivateChat : DefaultChat
    {
        public override Guid Id { get; }

        public override IMessage[] Messages { get; set; }

        public override IChatMember[] ChatMembers { get; set; }

        public override bool IsItPossibleToDeleteMessage(IUser chatMember, IMessage message)
        {
            return IsChatMember(chatMember) && DoesMessageExist(message) && FindMessage(message).SenderId == FindChatMember(chatMember).Id;
        }

        public override bool IsItPossibleToEditMessage(IUser chatMember, IMessage message)
        {
            return IsChatMember(chatMember) && DoesMessageExist(message) && FindMessage(message).SenderId == FindChatMember(chatMember).Id;
        }

        public override bool IsItPossibleToEditRoleOfChatMember(IUser editor, IUser editingPerson)
        {
            return false;
        }

        public override bool IsItPossibleToInviteUser(IUser inviter, IUser invitedPerson)
        {
            return false;
        }

        public override bool IsItPossibleToSendMessage(IUser chatMember)
        {
            return IsChatMember(chatMember);
        }

        public PrivateChat(IUser person1, IUser person2)
        {
            List<IChatMember> ListOfChatMembers = new List<IChatMember>()
            {
                new ChatMember(person1.Id, person1.NickName, ChatRole.User),
                new ChatMember(person2.Id, person2.NickName, ChatRole.User),
            };
            ChatMembers = ListOfChatMembers.ToArray();
            Messages = new IMessage[0];
            Id = Guid.NewGuid();
        }
    }
}
