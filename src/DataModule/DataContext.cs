using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProfileModule;

namespace DataModule
{
    public class DataContext: DbContext
    {
        private static readonly DataContext instance = new DataContext();
        public static DataContext Instance
        {
            get { return instance; }
        }

        public DbSet<IAccount> Accounts { get; set; }
        

        private DataContext() { }
    }
}
