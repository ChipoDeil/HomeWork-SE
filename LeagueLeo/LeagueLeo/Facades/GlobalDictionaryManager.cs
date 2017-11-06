using System;
using System.Collections.Generic;

namespace LeagueLeo
{
    public class GlobalDictionaryManager : IGlobalDictionaryManager
    {
        public Guid AddWord(Word word)
        {
            if (word == null)
                throw new Exception();
            Guid wordId = Guid.NewGuid();
            Word newWord = new Word(word.Original, word.Translation, wordId);
            _wordRepository.SaveWord(word);
            return wordId;
        }

        public Word GetWord(Guid wordId)
        {
            Word requestedWord = _wordRepository.LoadWord(wordId);
            if (requestedWord == null)
                throw new Exception();
            return requestedWord;
        }

        public IEnumerable<Word> GetAllWords()
        {
            return _wordRepository.LoadAllWords();
        }

        public GlobalDictionaryManager(IWordRepository wordRepository) {
            _wordRepository = wordRepository;
        }

        private readonly IWordRepository _wordRepository;
    }
}
