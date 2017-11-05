using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueGram
{
    public interface IChatMember
    {
        Guid Id { get; }

        string NickName { get; }

        ChatRole Role { get; set; }
    }
}
