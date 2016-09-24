using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ChatService.Models;

namespace ChatService.Data
{
    public class DataContext: DbContext
    {
        private static readonly DataContext instance = new DataContext();
        public static DataContext Instance
        {
            get { return instance; }
        }

        public DbSet<Account> Accounts { get; set; }

        private DataContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=test;Integrated Security=True;");
        }
    }
}
