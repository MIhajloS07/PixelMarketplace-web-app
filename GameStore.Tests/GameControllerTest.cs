using GameStore.Data;
using GameStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Tests
{
    public class GameControllerTest
    {
        private GameStoreContext GetContext()
        {
            var options = new DbContextOptionsBuilder<GameStoreContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()) // new db every dotnet test
                .Options;
            return new GameStoreContext(options);
        }

        [Fact]
        public async Task Index_ReturnsViewResult()
        {
            using var context = GetContext();
            context.Games.Add(new Game { Title = "Halo", Author = "Bungie", Price = 50 });
            await context.SaveChangesAsync();

            var controller = new GamesController(context);
            var result = await controller.Index(null);

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Details_ReturnsCorrectGame()
        {
            using var context = GetContext();
            var game = new Game { Title = "Halo", Author = "Bungie", Price = 50 };
            context.Games.Add(game);
            await context.SaveChangesAsync();

            var controller = new GamesController(context);
            var result = await controller.Details(game.Id);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Game>(viewResult.Model);
            Assert.Equal("Halo", model.Title);
        }

        [Fact]
        public async Task Create_AddsGameToDatabase()
        {
            using var context = GetContext();
            var controller = new GamesController(context);

            var game = new Game { Title = "Halo", Author = "Bungie", Price = 50 };
            var result = await controller.Create(game);

            Assert.IsType<RedirectToActionResult>(result);
            Assert.Single(context.Games);
            Assert.Equal("Halo", context.Games.First().Title);
        }

        [Fact]
        public async Task Delete_RemovesGameFromDatabase()
        {
            using var context = GetContext();
            var game = new Game { Title = "Halo", Author = "Bungie", Price = 50 };
            context.Games.Add(game);
            await context.SaveChangesAsync();

            var controller = new GamesController(context);
            var result = await controller.DeleteConfirmed(game.Id);    

            Assert.IsType<RedirectToActionResult>(result);
            Assert.Empty(context.Games);
        }

        [Fact]
        public async Task Details_ReturnsNotFound_WhenGameDoesNotExist()
        {
            using var context = GetContext();
            var controller = new GamesController(context);
            var result = await controller.Details(999); // nonexistent id
            Assert.IsType<NotFoundResult>(result);
        }
    }
}