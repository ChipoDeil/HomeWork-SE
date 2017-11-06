using System;

namespace LeagueLeo.Facades
{
    public interface IUserManager
    {
        Guid AddUser(string nickname);
        
    }
}
