using System;
using Microsoft.EntityFrameworkCore;

namespace Tournament
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Fansappdb;Trusted_Connection=True;");
        }
    }
    public class ApplicationContext2 : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=playersapp.db");
        }
    }
}
