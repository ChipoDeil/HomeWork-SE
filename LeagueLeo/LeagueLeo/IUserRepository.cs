using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueLeo
{
    public interface IUserRepository
    {
        IUser LoadUser(Guid userId);
        void SaveUser(IUser user);
    }
}
