using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueGram
{
    internal class User : IUser
    {
        public Guid Id { get; }

        public string NickName { get; }
        public IChat[] Chats { get; set; }

        public User(Guid id, string nickName) {
            Id = id;
            NickName = nickName;
            Chats = new IChat[0];
        }
    }
}
