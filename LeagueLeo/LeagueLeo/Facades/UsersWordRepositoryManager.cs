using System;
using System.Collections.Generic;

namespace LeagueLeo.Facades
{
    public class UsersWordRepositoryManager : IUsersWordRepositoryManager
    {
        public Guid AddWordForUser(Word word, Guid userId)
        {
            if (word == null || userId == null)
                throw new ArgumentNullException();
            _userRepository.LoadUser(userId);
            Guid newId = Guid.NewGuid();
            Word newWord = new Word(word.Original, word.Translation, newId);
            _usersWordRepository.AddWordForUser(userId, newWord);
            return newId;
        }

        public IEnumerable<Word> LoadWordsForUser(Guid userId)
        {
            if (userId == null)
                throw new ArgumentNullException();
            _userRepository.LoadUser(userId);
            return _usersWordRepository.LoadWordsForUser(userId);
        }

        public UsersWordRepositoryManager(IUsersWordRepository usersWordRepository, IUserRepository userRepository) {
            _usersWordRepository = usersWordRepository ?? throw new ArgumentNullException();
            _userRepository = userRepository ?? throw new ArgumentNullException();
        }

        private readonly IUsersWordRepository _usersWordRepository;
        private readonly IUserRepository _userRepository;
    }
}
