using System;

namespace LeagueLeo
{
    public interface IUserRepository
    {
        User LoadUser(Guid userId);
        void SaveUser(User user);
    }
}
