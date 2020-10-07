using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilkioPersonalBot
{
    public class MyDbContext : DbContext
    {
        public DbSet<SubResponceDb> SubResponces { get; set; }
        public MyDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder ob)
        {
            ob.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=clientdb;Trusted_Connection=True;");
        }
    }
}
