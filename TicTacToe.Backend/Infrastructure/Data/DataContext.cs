using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext() { }

        public DbSet<Game> Games => Set<Game>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Invite> Invites => Set<Invite>();

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);
            options.UseNpgsql("Host=localhost;Port=6000;Database=tictactoe;Username=postgres;Password=lomalvas123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
