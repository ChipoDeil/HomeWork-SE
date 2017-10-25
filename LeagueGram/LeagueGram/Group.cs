using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueGram
{
    class Group : DefaultChat
    {
        public override Guid Id { get; }
        public override IMessage[] Messages { get; set; }
        public override IChatMember[] ChatMembers { get; set; }

        public override void DeleteMessage(IUser chatMember, IMessage message)
        {
            if (!IsChatMember(chatMember))
                throw new InvalidOperationException();
            IChatMember currentMember = FindChatMember(chatMember);
            IMessage currentMessage = null;
            foreach (IMessage locMessage in Messages) {
                if(locMessage.MessageId == message.MessageId)
                {
                    currentMessage = locMessage;
                    break;
                }
            }
            if(currentMessage == null)
                throw new InvalidOperationException();
            if (!(currentMessage.SenderId == currentMember.Id || currentMember.Role == ChatRole.Creator || currentMember.Role == ChatRole.Admin))
                throw new InvalidOperationException();
            List<IMessage> listOfMessages = new List<IMessage>(Messages);
            listOfMessages.Remove(message);
            Messages = listOfMessages.ToArray();
        }

        public override void EditMessage(IUser chatMember, IMessage message, string newMessage)
        {
            if (!IsChatMember(chatMember))
                throw new InvalidOperationException();
            IChatMember currentMember = FindChatMember(chatMember);
            IMessage currentMessage = null;
            foreach (IMessage locMessage in Messages)
            {
                if (locMessage.SenderId == chatMember.Id)
                {
                    currentMessage = locMessage;
                    break;
                }
            }
            if (currentMessage == null)
                throw new InvalidOperationException();
            List<IMessage> listOfMessages = new List<IMessage>(Messages);
            listOfMessages.Find(current => current.SenderId == currentMember.Id).Text = newMessage;
            Messages = listOfMessages.ToArray();
        }

        public override void EditRoleOfChatMember(IUser editor, IUser editingPerson, ChatRole newRole)
        {
            if (!IsChatMember(editor) || !IsChatMember(editingPerson))
                throw new InvalidOperationException();
            IChatMember currentMember = FindChatMember(editor);
            if (!(currentMember.Role == ChatRole.Creator))
                throw new InvalidOperationException();
            List<IChatMember> listOfChatMembers = new List<IChatMember>(ChatMembers);
            listOfChatMembers.Find(current => current.Id == editingPerson.Id).Role = newRole;
            ChatMembers = listOfChatMembers.ToArray();
        }

        public override void InviteUser(IUser inviter, IUser invitedPerson)
        {
            if(!IsChatMember(inviter))
                throw new InvalidOperationException();
            IChatMember currentMember = FindChatMember(inviter);
            if (currentMember.Role == ChatRole.Unknown)
                throw new InvalidOperationException();
            
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
            if (currentMember.Role != ChatRole.Unknown)
                return true;
            return false;
        }

        public override void SendMessage(IUser chatMember, string message)
        {
            if (!IsChatMember(chatMember))
                throw new InvalidOperationException();
            IChatMember currentMember = FindChatMember(chatMember);
            if(currentMember.Role == ChatRole.Unknown)
                throw new InvalidOperationException();
            List<IMessage> listOfMessages = new List<IMessage>(Messages)
            {
                new Message(Guid.NewGuid(), message, chatMember.Id, DateTimeOffset.Now)
            };
            Messages = listOfMessages.ToArray();
        }

        public Group(IUser creator) {
            List<IChatMember> listOfChatMembers = new List<IChatMember>
            {
                new ChatMember(creator.Id, creator.NickName, ChatRole.Creator)
            };
            ChatMembers = listOfChatMembers.ToArray();
            Id = Guid.NewGuid();
        }
    }
}
