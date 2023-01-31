using SwapMeAngularAuthAPI.Context;
using SwapMeAngularAuthAPI.Dtos;
using SwapMeAngularAuthAPI.Helpers;
using SwapMeAngularAuthAPI.Models;

namespace SwapMeAngularAuthAPI.Handlers
{
    public class GamesHandler
    {
        private readonly GamesDbContext _gamesContext;

        public GamesHandler(GamesDbContext gamesContext)
        {
            _gamesContext = gamesContext;
        }
        public async Task HandleGameAddAsync(GameDto gameObj)
        {
            var dbGame = new Game
            {
                Name = gameObj.Name,

                Genre = new Genre
                {
                    Name = gameObj.GenreName
                },

                GameImage = new GameImage
                {
                    Image = gameObj.Image
                }
            };

            await _gamesContext.Games.AddAsync(dbGame);
            await _gamesContext.SaveChangesAsync();
        }
    }
}
