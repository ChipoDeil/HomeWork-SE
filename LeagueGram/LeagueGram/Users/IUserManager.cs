using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueGram
{
    public interface IUserManager
    {
        IUser[] Users { get; set; }

        void JoinChat(Guid userId, IChat chat);

        IUser GetUserById(Guid userId);

        bool DoesUserExist(Guid userId);

        Guid RegisterUser(string nickName);
    }
}
