using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileModule
{
    public interface IFriendlist
    {
        IAccount Owner { get; }
        IList<IAccount> Friends { get; }
    }
}
