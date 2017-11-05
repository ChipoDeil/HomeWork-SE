using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeagueLeo
{
    public class InJsonUserRepository : IUserRepository
    {
        string userFile = Properties.userFile;
        string pathFile = Properties.currentDirectory;
        private List<User> listOfUsers = new List<User>();
        DealWithFile dealWithFile = new DealWithFile();

        public User LoadUser(Guid userId)
        {
            return listOfUsers.Find(current => current.Id == userId);
        }

        public void SaveUser(User user)
        {
            listOfUsers.Add(user);
            dealWithFile.SaveToFile(pathFile, userFile, listOfUsers);
        }

        public InJsonUserRepository() {
            if(dealWithFile.ReadFromFile<List<User>>(pathFile, userFile) != null)
                listOfUsers = dealWithFile.ReadFromFile<List<User>>(pathFile, userFile);
        }
    }
}
