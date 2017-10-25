using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueGram
{
    internal class ChatFactory
    {
        List<IChat> listOfCreatedChats;

        public void CreatePrivateChat(IUser person1, IUser person2)
        {
            PrivateChat privateChat = new PrivateChat(person1, person2);
            listOfCreatedChats.Add(privateChat);
        }

        public void CreateChannel(IUser creator)
        {
            Channel channel = new Channel(creator);
            listOfCreatedChats.Add(channel);
        }

        public void CreateGroup(IUser creator)
        {
            Group group = new Group(creator);
            listOfCreatedChats.Add(group);
        }

        public ChatFactory() {
            listOfCreatedChats = new List<IChat>();
        }
    }
}
