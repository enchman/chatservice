using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileModule
{
    public interface IAccount
    {
        int Id { get; set; }
        string Username { get; set; }
        string DisplayName { get; set; }
        byte[] Password { get; set; }
    }
}
