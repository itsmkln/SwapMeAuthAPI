using SwapMeAngularAuthAPI.Context;
using SwapMeAngularAuthAPI.Dtos;
using SwapMeAngularAuthAPI.Models.Entities;

namespace SwapMeAngularAuthAPI.Handlers
{
    public class RequiredGamesHandler
    {
        private readonly ApplicationDbContext _applicationContext;

        public RequiredGamesHandler(ApplicationDbContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public async Task AddRequiredGamesAsync()
        {
            var dbGame = new Game
            {
                Name = "Grand Theft Auto V",
                GenreId = 11,
            };
            await _applicationContext.Games.AddAsync(dbGame);

            //dbGame = new Game
            //{
            //    Name = "Red Dead Redemption 2",
            //    GenreId = 2,
            //};
            //await _applicationContext.Games.AddAsync(dbGame);

            //dbGame = new Game
            //{
            //    Name = "Hades",
            //    GenreId = 11,
            //};
            //await _applicationContext.Games.AddAsync(dbGame);

            dbGame = new Game
            {
                Name = "FIFA 23",
                GenreId = 5,
            };
            await _applicationContext.Games.AddAsync(dbGame);

            dbGame = new Game
            {
                Name = "Half Life 2",
                GenreId = 1,
            };
            await _applicationContext.Games.AddAsync(dbGame);

            dbGame = new Game
            {
                Name = "Hollow Knight",
                GenreId = 7,
            };
            await _applicationContext.Games.AddAsync(dbGame);

            dbGame = new Game
            {
                Name = "Forklift Simulator 2019",
                GenreId = 4,
            };
            await _applicationContext.Games.AddAsync(dbGame);

            dbGame = new Game
            {
                Name = "Mortal Kombat 11",
                GenreId = 6,
            };
            await _applicationContext.Games.AddAsync(dbGame);




            await _applicationContext.SaveChangesAsync();
        }
    }
}
