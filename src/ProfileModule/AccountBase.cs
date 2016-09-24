using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileModule
{
    public abstract class AccountBase: IAccount
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public byte[] Password { get; set; }

        private AccountBase() { }
    }
}
