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

        public override void DeleteMessage(IUser chatMember, IMessage message)
        {
            if(!IsChatMember(chatMember))
                throw new InvalidOperationException();
            IChatMember currentMember = FindChatMember(chatMember);
            if (currentMember.Role == ChatRole.Creator)
            {
                List<IMessage> listOfMessages = new List<IMessage>(Messages);
                listOfMessages.Remove(message);
                Messages = listOfMessages.ToArray();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public override void EditMessage(IUser chatMember, IMessage message, string newMessage)
        {
            if (!IsChatMember(chatMember))
                throw new InvalidOperationException();
            IChatMember currentMember = FindChatMember(chatMember);
            if (currentMember.Role == ChatRole.Creator)
            {
                List<IMessage> listOfMessages = new List<IMessage>(Messages);
                listOfMessages.Find(current => current.MessageId == message.MessageId).Text = newMessage;
                Messages = listOfMessages.ToArray();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public override void EditRoleOfChatMember(IUser editor, IUser editingPerson, ChatRole newRole)
        {
            throw new NotSupportedException();
        }

        public override void InviteUser(IUser inviter, IUser invitedPerson)
        {
            if (!IsChatMember(inviter))
                throw new InvalidOperationException();
            IChatMember currentMember = FindChatMember(inviter);
            List<IChatMember> listOfChatMembers = new List<IChatMember>(ChatMembers)
            {
                new ChatMember(invitedPerson.Id, invitedPerson.NickName, ChatRole.User)
            };
            ChatMembers = listOfChatMembers.ToArray();

        }

        public override bool IsItPossibleToSendMessage(IUser chatMember)
        {
            if (!IsChatMember(chatMember))
                throw new InvalidOperationException();
            IChatMember currentMember = FindChatMember(chatMember);
            if (currentMember.Role == ChatRole.Creator)
                return true;
            return false;
        }

        public override void SendMessage(IUser chatMember, string Message)
        {
            if(!IsChatMember(chatMember))
                throw new InvalidOperationException();
            IChatMember currentMember = FindChatMember(chatMember);
            if (currentMember.Role == ChatRole.Creator)
            {
                List<IMessage> listOfMessages = new List<IMessage>(Messages)
                {
                    new Message(Guid.NewGuid(), Message, chatMember.Id, DateTimeOffset.Now)
                };
                Messages = listOfMessages.ToArray();
            }
            else
            {
                throw new Exception("Permissions denied");
            }

        }

        public Channel(IUser creator) {
            List<IChatMember> listOfChatMembers = new List<IChatMember>
            {
                new ChatMember(creator.Id, creator.NickName, ChatRole.Creator)
            };
            ChatMembers = listOfChatMembers.ToArray();
            Id = Guid.NewGuid();
        }
    }
}
