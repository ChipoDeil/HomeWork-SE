using System;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("LeagueLeoTests")]
namespace LeagueLeo
{
    internal class User : IUser
    {
        public string NickName { get; }

        public Guid Id { get; }

        public User(string nickName, Guid id)
        {
            NickName = nickName;
            Id = id;
        }
    }
}
