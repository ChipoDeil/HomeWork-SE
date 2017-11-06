using System;

namespace LeagueLeo.Facades
{
    public class UserManager : IUserManager
    {
        public Guid AddUser(string nickname)
        {
            if (nickname == null)
                throw new ArgumentNullException();
            Guid userId = Guid.NewGuid();
            User newUser = new User(nickname, userId);
            _userRepository.SaveUser(newUser);
            return userId;
        }

        public UserManager(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        private readonly IUserRepository _userRepository;
    }
}
