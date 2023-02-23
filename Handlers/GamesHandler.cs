using SwapMeAngularAuthAPI.Context;
using SwapMeAngularAuthAPI.Dtos;
using SwapMeAngularAuthAPI.Helpers;
using SwapMeAngularAuthAPI.Models.Entities;

namespace SwapMeAngularAuthAPI.Handlers
{
    public class GamesHandler
    {
        private readonly ApplicationDbContext _applicationContext;

        public GamesHandler(ApplicationDbContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public async Task HandleGameAddAsync(GameDto gameObj)
        {
            var dbGame = new Game
            {
                Name = gameObj.Name,

                GenreId = gameObj.GenreId,

                //Image = new Image
                //{
                //    ImageFile = gameObj.ImageFile
                //}
            };

            await _applicationContext.Games.AddAsync(dbGame);
            await _applicationContext.SaveChangesAsync();
        }
    }
}
