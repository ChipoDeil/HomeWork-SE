using System;
using System.Collections.Generic;

namespace LeagueGram
{
    internal class PrivateChat : DefaultChat
    {
        public override Guid Id { get; }

        public override IMessage[] Messages { get; set; }

        public override IChatMember[] ChatMembers { get; set; }

        public override void DeleteMessage(IUser chatMember, IMessage message)
        {
            if(!IsChatMember(chatMember))
                throw new InvalidOperationException();
            foreach(Message locMessage in Messages)
            {
                if (locMessage.MessageId == message.MessageId && locMessage.SenderId == chatMember.Id)
                {
                    List<IMessage> messages = new List<IMessage>(Messages);
                    messages.Remove(locMessage);
                    Messages = messages.ToArray();
                    break;
                }
            }
        }

        public override void EditMessage(IUser chatMember, IMessage message, string newMessage)
        {
            if (!IsChatMember(chatMember))
                throw new InvalidOperationException();
            foreach (Message locMessage in Messages)
            {
                if (locMessage.MessageId == message.MessageId && locMessage.SenderId == chatMember.Id)
                {
                    List<IMessage> messages = new List<IMessage>(Messages);
                    messages.Find(current => current.MessageId == locMessage.MessageId).Text = newMessage;
                    Messages = messages.ToArray();
                    break;
                }
            }
        }

        public override bool IsItPossibleToSendMessage(IUser chatMember)
        {
            return IsChatMember(chatMember);
        }

        public override void EditRoleOfChatMember(IUser editor, IUser editingPerson, ChatRole newRole)
        {
            throw new NotSupportedException();
        }

        public override void InviteUser(IUser inviter, IUser invitedPerson)
        {
            throw new NotSupportedException();
        }

        public override void SendMessage(IUser chatMember, string message)
        {
            if (!IsChatMember(chatMember))
                throw new InvalidOperationException();
            List<IMessage> messages = new List<IMessage>(Messages) { new Message(Guid.NewGuid(), message, chatMember.Id, DateTimeOffset.Now) };
            Messages = messages.ToArray();
        }

        public PrivateChat(IUser person1, IUser person2)
        {
            List<IChatMember> ListOfChatMembers = new List<IChatMember>()
            {
                new ChatMember(person1.Id, person1.NickName, ChatRole.User),
                new ChatMember(person2.Id, person2.NickName, ChatRole.User),
            };
            ChatMembers = ListOfChatMembers.ToArray();
            Id = Guid.NewGuid();
        }
    }
}
