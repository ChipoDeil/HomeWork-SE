using System;
using System.Collections.Generic;

namespace LeagueLeo
{
    public interface IUserRepository
    {
        User LoadUser(Guid userId);
        IEnumerable<User> GetAllUsers();
        void SaveUser(User user);
    }
}
