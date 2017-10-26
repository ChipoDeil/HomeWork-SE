using System;
using System.Collections.Generic;
using System.Text;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("PrivateChatTester")]
namespace LeagueGram
{
    
    internal class ChatFactory
    {
        public List<IChat> ListOfCreatedChats { get; set; }

        public void CreatePrivateChat(IUser person1, IUser person2)
        {
            PrivateChat privateChat = new PrivateChat(person1, person2);
            ListOfCreatedChats.Add(privateChat);
        }

        public void CreateChannel(IUser creator)
        {
            Channel channel = new Channel(creator);
            ListOfCreatedChats.Add(channel);
        }

        public void CreateGroup(IUser creator)
        {
            Group group = new Group(creator);
            ListOfCreatedChats.Add(group);
        }

        public ChatFactory() {
            ListOfCreatedChats = new List<IChat>();
        }
    }
}
