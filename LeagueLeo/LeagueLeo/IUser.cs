using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueLeo
{
    public interface IUser
    {
        string NickName { get; }
        Guid Id { get; }
    }
}
