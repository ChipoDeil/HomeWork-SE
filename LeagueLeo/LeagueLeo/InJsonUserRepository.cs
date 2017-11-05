using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeagueLeo
{
    internal class InJsonUserRepository : IUserRepository
    {
        string userFile = Properties.userFile;
        string pathFile = Properties.currentDirectory;
        private List<User> listOfUsers = new List<User>();
        DealWithFile dealWithFile = new DealWithFile();

        public IUser LoadUser(Guid userId)
        {
            listOfUsers = dealWithFile.ReadFromFile<List<User>>(pathFile, userFile);
            return listOfUsers.Find(current => current.Id == userId);
        }

        public void SaveUser(IUser user)
        {
            listOfUsers.Add(user);
            dealWithFile.SaveToFile(pathFile, userFile, listOfUsers);
        }

        internal InJsonUserRepository() {
        }
    }
}
