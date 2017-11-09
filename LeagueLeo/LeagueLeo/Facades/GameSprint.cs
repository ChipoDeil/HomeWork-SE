using System;
using System.Collections.Generic;
using System.Linq;
using LeagueLeo.Domain.Exception;

namespace LeagueLeo.Facades
{
    public class GameSprint : IGameSprint
    {
        public Word GetRandomWord()
        {

            List<Word> listOfUsersWords = _usersWordRepository.LoadWordsForUser(currentUserId).ToList();
            List<Word> unstudied = listOfUsersWords.FindAll(current => current.Points < pointsToTreatWordAsStudied);

            int randomTranslationIndex = random.Next(0, unstudied.Count);
            int randomOriginalIndex = random.Next(0, unstudied.Count);

            Word randomTranslation = unstudied[randomTranslationIndex];
            Word randomOriginal = unstudied[randomOriginalIndex];

            Word returningWord = new Word(randomOriginal.Original, randomTranslation.Translation, Guid.NewGuid());

            return returningWord;
        }

        public IEnumerable<Word> GetUnstudiedWords()
        {

            List<Word> listOfUsersWords = _usersWordRepository.LoadWordsForUser(currentUserId).ToList();

            return listOfUsersWords.FindAll(current => current.Points < pointsToTreatWordAsStudied).ToArray();
        }

        public bool IsAnswerRight(string original, string translation, bool right)
        {

            if (original == null || translation == null)
                throw new ArgumentNullException(); 

            List<Word> listOfUsersWords = _usersWordRepository.LoadWordsForUser(currentUserId).ToList();
            List<Word> unstudied = listOfUsersWords.FindAll(current => current.Points < pointsToTreatWordAsStudied);

            Word currentWord = unstudied.Find(current => current.Original == original);

            if (currentWord == null)
                throw new WordNotFoundException("word " + original + " not found");

            if (currentWord.Points >= pointsToTreatWordAsStudied)
                throw new WordAlreadyStudiedException(currentWord.Id);

            if (currentWord.Translation == translation && right || !right && currentWord.Translation != translation) {
                _usersWordRepository.AddPointsToWordForUser(currentUserId, currentWord);
                return true;
            }

            return false;
        }

        private void StartGameForUser(Guid userId)
        {
            _userRepository.LoadUser(userId);
            List<Word> listOfWords = _usersWordRepository.LoadWordsForUser(userId).ToList();
            List<Word> unstudied = listOfWords.FindAll(current => current.Points < pointsToTreatWordAsStudied);
            if (unstudied.Count < minWordForSprint)
                throw new NotEnoughUnstudiedWordsToStartSprintException(userId);
            currentUserId = userId;
        }

        public GameSprint(IUsersWordRepository usersWordRepository, IUserRepository userRepository, Guid userId) {
            _usersWordRepository = usersWordRepository;
            _userRepository = userRepository;
            StartGameForUser(userId);
        }

        private readonly IUsersWordRepository _usersWordRepository;
        private readonly IUserRepository _userRepository;

        private int pointsToTreatWordAsStudied = Properties.minPointsOfWordToTreatAsStudied;
        private int minWordForSprint = Properties.minWordsToStartSplit;

        private Guid currentUserId;
        private Random random = new Random();

    }
}
