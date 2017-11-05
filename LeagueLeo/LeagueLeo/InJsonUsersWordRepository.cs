using System;
using System.Collections.Generic;
using System.Linq;

namespace LeagueLeo
{
    public class InJsonUsersWordRepository : IUsersWordRepository
    {
        private Dictionary<Guid, List<Word>> vocForUsers = new Dictionary<Guid, List<Word>>();
        string pathFile = Properties.currentDirectory + Properties.splitDirectory;
        string fileName = Properties.vocFile;
        DealWithFile dealWithFile = new DealWithFile();

        public void AddPointsToWordForUser(Guid userId, Word word)
        {
            if (!vocForUsers.ContainsKey(userId))
            {
                //throw new exeption
            }

            if (vocForUsers[userId].Find(current => current.Id == word.Id) == null)
            {
                //throw new exeption
            }

            vocForUsers[userId].Find(current => current.Id == word.Id).AddPoint();
            dealWithFile.SaveToFile(pathFile, fileName, vocForUsers);
        }

        public void AddWordForUser(Guid userId, Word word)
        {
            if (!vocForUsers.ContainsKey(userId))
            {
                List<Word> newList = new List<Word>();
                vocForUsers.Add(userId, newList);
            }

            vocForUsers[userId].Add(word);
            dealWithFile.SaveToFile(pathFile, fileName, vocForUsers);
        }

        public IEnumerable<Word> LoadWordsForUser(Guid userId)
        {
            return vocForUsers.First(current => current.Key== userId).Value.ToArray();
        }

        public InJsonUsersWordRepository() {
            if (dealWithFile.ReadFromFile<Dictionary<Guid, List<Word>>>(pathFile, fileName) != null)
                vocForUsers = dealWithFile.ReadFromFile<Dictionary<Guid, List<Word>>>(pathFile, fileName);
        }
    }
}
