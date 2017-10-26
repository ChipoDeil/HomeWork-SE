using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueGram
{
    internal class UserManager : IUserManager
    {
        public IUser[] Users { get; set; }

        public void JoinChat(Guid userId, IChat chat)
        {
            if (!DoesUserExist(userId))
                throw new Exception("user does not exist");
            List<IUser> usersList = new List<IUser>(Users);
            IUser currentUser = usersList.Find(current => current.Id == userId);
            IChat[] currentChats = currentUser.Chats;
            List<IChat> chatsList = new List<IChat>(currentChats);
            chatsList.Add(chat);
            currentChats = chatsList.ToArray();
            currentUser.Chats = currentChats;
        }

        public Guid RegisterUser(string nickName)
        {
            Guid newId = Guid.NewGuid();
            List<IUser> usersList = new List<IUser>(Users);
            usersList.Add(new User(newId, nickName));
            Users = usersList.ToArray();
            return newId;
        }

        public bool DoesUserExist(Guid userId) {
            foreach (IUser user in Users) {
                if (user.Id == userId)
                    return true;
            }
            return false;
        }

        public IUser GetUserById(Guid userId) {
            if(!DoesUserExist(userId))
                throw new Exception("user does not exist");
            List<IUser> usersList = new List<IUser>(Users);
            return usersList.Find(current => current.Id == userId);
        }

        public UserManager() {
            Users = new IUser[0];
        }
    }
}
