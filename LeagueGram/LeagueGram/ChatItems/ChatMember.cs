using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueGram
{
    internal class ChatMember : IChatMember
    {
        public Guid Id { get; }

        public string NickName { get; }

        public ChatRole Role { get; set; }

        public ChatMember(Guid id, string nickName, ChatRole role) {
            Id = id;
            NickName = nickName;
            Role = role;
        }
    }
}
