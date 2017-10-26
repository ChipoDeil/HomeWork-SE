using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueGram
{
    public interface IUser
    {
        Guid Id { get; }
        string NickName { get; }

        IChat Chats { get; set; }

    }
}
