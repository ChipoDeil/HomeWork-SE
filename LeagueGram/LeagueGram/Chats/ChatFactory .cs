using System;
using System.Collections.Generic;

namespace LeagueGram
{
    
    internal class ChatFactory
    {
        public List<IChat> ListOfCreatedChats { get; set; }

        public IChat CreatePrivateChat(IUser person1, IUser person2)
        {
            PrivateChat privateChat = new PrivateChat(person1, person2);
            ListOfCreatedChats.Add(privateChat);
            return privateChat;
        }

        public IChat CreateChannel(IUser creator)
        {
            Channel channel = new Channel(creator);
            ListOfCreatedChats.Add(channel);
            return channel;
        }

        public IChat CreateGroup(IUser creator)
        {
            Group group = new Group(creator);
            ListOfCreatedChats.Add(group);
            return group;
        }

        public IChat GetChatById(Guid chatId) {
            IChat currentChat = ListOfCreatedChats.Find(current => current.Id == chatId);
            if (currentChat == null)
                throw new Exception("Chat does not exist");
            return currentChat;
        }

        public ChatFactory() {
            ListOfCreatedChats = new List<IChat>();
        }
    }
}
