using GameStore.Models;

namespace GameStore.Tests
{
    public class GameModelTest
    {
        [Fact]
        public void Price_ShouldBePositive()
        {
            var game = new Game { Price = 50 };
            Assert.True(game.Price > 0);
        }

        [Fact]
        public void Title_ShouldNotBeEmpty()
        {
            var game = new Game { Author = "Halo" };
            Assert.False(string.IsNullOrEmpty(game.Author));
        }

        [Fact]
        public void Author_ShouldNotBeEmpty()
        {
            var game = new Game { Author = "Test" };
            Assert.False(string.IsNullOrEmpty(game.Author));
        }

        [Fact]
        public void Game_WithValidData_ShouldBeCreated()
        {
            var game = new Game
            {
                Title = "Test Game",
                Author = "Test Author",
                Price = 40,
                releaseDate = new DateTime(1993, 12, 10)
            };
            Assert.Equal("Test Game", game.Title);
            Assert.Equal("Test Author", game.Author);
            Assert.Equal(40, game.Price);
            Assert.Equal(new DateTime(1993, 12, 10), game.releaseDate);
        }

        [Fact]
        public void ReleaseDate_ShouldNotBeFuture()
        {
            var game = new Game { releaseDate = DateTime.Now.AddDays(-1) };
            Assert.True(game.releaseDate <= DateTime.Now);
        }
    }
}
