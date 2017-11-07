using System;
using System.Collections.Generic;

namespace LeagueLeo.Facades
{
    public interface IUserManager
    {
        Guid AddUser(string nickname);
        IEnumerable<User> GetAllUsers();
    }
}
