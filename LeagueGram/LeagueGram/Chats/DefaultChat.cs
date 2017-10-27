using System;
using System.Collections.Generic;

namespace LeagueGram
{
    internal abstract class DefaultChat : IChat
    {
        public abstract Guid Id { get; }
        public abstract IMessage[] Messages { get; protected set; }
        public abstract IChatMember[] ChatMembers { get; set; }

        public void DeleteMessage(IUser chatMember, IMessage message) {
            if (!IsItPossibleToDeleteMessage(chatMember, message))
                throw new Exception("It is not possible for user to delete message");
            List<IMessage> listOfMessages = new List<IMessage>(Messages);
            listOfMessages.Remove(message);
            Messages = listOfMessages.ToArray();
        }

        public abstract bool IsItPossibleToDeleteMessage(IUser chatMember, IMessage message);

        public void EditMessage(IUser chatMember, IMessage message, string newMessage)
        {
            if (!IsItPossibleToEditMessage(chatMember, message))
                throw new Exception("It is not possible to edit message for user");
            foreach (Message locMessage in Messages)
            {
                if (locMessage.MessageId == message.MessageId)
                {
                    List<IMessage> messages = new List<IMessage>(Messages);
                    messages.Find(current => current.MessageId == locMessage.MessageId).Text = newMessage;
                    Messages = messages.ToArray();
                    break;
                }
            }
        }
        public abstract bool IsItPossibleToEditMessage(IUser chatMember, IMessage message);

        public void EditRoleOfChatMember(IUser editor, IUser editingPerson, ChatRole newRole)
        {
            if (!IsItPossibleToEditRoleOfChatMember(editor, editingPerson))
                throw new Exception("It is not possible to Edit Role Of ChatMember");
            List<IChatMember> listOfChatMembers = new List<IChatMember>(ChatMembers);
            listOfChatMembers.Find(current => current.Id == editingPerson.Id).Role = newRole;
            ChatMembers = listOfChatMembers.ToArray();
        }

        public abstract bool IsItPossibleToEditRoleOfChatMember(IUser editor, IUser editingPerson);

        public void InviteUser(IUser inviter, IUser invitedPerson)
        {
            if (!IsItPossibleToInviteUser(inviter, invitedPerson))
                throw new Exception("It is not possible to invite user");
            List<IChatMember> listOfChatMembers = new List<IChatMember>(ChatMembers)
            {
                new ChatMember(invitedPerson.Id, invitedPerson.NickName, ChatRole.User)
            };
            ChatMembers = listOfChatMembers.ToArray();
        }

        public abstract bool IsItPossibleToInviteUser(IUser inviter, IUser invitedPerson);

        public void SendMessage(IUser chatMember, string message) {
            if (!IsItPossibleToSendMessage(chatMember))
                throw new Exception("It is not possible to send message for user");
            List<IMessage> messages = new List<IMessage>(Messages);
            messages.Add(new Message(Guid.NewGuid(), message, chatMember.Id, DateTimeOffset.Now));
            Messages = messages.ToArray();
        }

        public abstract bool IsItPossibleToSendMessage(IUser chatMember);

        public bool IsChatMember(IUser chatMember)
        {
            foreach (IChatMember locChatMember in ChatMembers)
            {
                if (locChatMember.Id == chatMember.Id)
                    return true;
            }
            return false;
        }

        public IChatMember FindChatMember(IUser chatMember) {
            foreach (IChatMember locChatMember in ChatMembers)
            {
                if (locChatMember.Id == chatMember.Id)
                    return locChatMember;
            }
            return null;
        }

        public bool DoesMessageExist(IMessage message) {
            foreach (IMessage locMessage in Messages)
            {
                if (locMessage.MessageId == message.MessageId)
                    return true;
            }
            return false;
        }

        public IMessage FindMessage(IMessage message) {
            foreach (IMessage locMessage in Messages)
            {
                if (locMessage.MessageId == message.MessageId)
                    return locMessage;
            }
            return null;
        }

        public IMessage FindMessageById(Guid messageId)
        {
            foreach (IMessage locMessage in Messages)
            {
                if (locMessage.MessageId == messageId)
                    return locMessage;
            }
            return null;
        }
    }
}
