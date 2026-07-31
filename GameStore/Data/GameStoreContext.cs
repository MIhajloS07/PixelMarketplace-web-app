using Microsoft.EntityFrameworkCore;
using GameStore.Models;

namespace GameStore.Data
{
    public class GameStoreContext : DbContext
    {
        public GameStoreContext(DbContextOptions<GameStoreContext> options) 
            : base(options) { }

        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>().HasData(
                new Game
                {
                    Id = 1,
                    Title = "Halo",
                    Author = "Bungie",
                    Price = 50,
                    releaseDate = new DateTime(2001, 11, 15)
                },
                new Game
                {
                    Id = 2,
                    Title = "Half-Life",
                    Author = "Valve",
                    Price = 20,
                    releaseDate = new DateTime(1998, 11, 19)
                },
                new Game
                {
                    Id = 3,
                    Title = "The Witcher 3",
                    Author = "CD Projekt",
                    Price = 30,
                    releaseDate = new DateTime(2015, 5, 19)
                }
            );
        }
    }
}
