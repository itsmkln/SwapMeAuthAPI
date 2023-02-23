using SwapMeAngularAuthAPI.Context;
using SwapMeAngularAuthAPI.Dtos;
using SwapMeAngularAuthAPI.Models.Entities;

namespace SwapMeAngularAuthAPI.Handlers
{
    public class RequiredGenresHandler
    {
        private readonly ApplicationDbContext _applicationContext;

        public RequiredGenresHandler(ApplicationDbContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public async Task AddRequiredGenresAsync()
        {
            var dbGenre = new Genre
            {
                Name = "FPS"
            };
            await _applicationContext.Genres.AddAsync(dbGenre);

            dbGenre = new Genre
            {
                Name = "RPG"
            };
            await _applicationContext.Genres.AddAsync(dbGenre);

            dbGenre = new Genre
            {
                Name = "Adventure"
            };
            await _applicationContext.Genres.AddAsync(dbGenre);

            dbGenre = new Genre
            {
                Name = "Simulation"
            };
            await _applicationContext.Genres.AddAsync(dbGenre);

            dbGenre = new Genre
            {
                Name = "Sports"
            };
            await _applicationContext.Genres.AddAsync(dbGenre);

            dbGenre = new Genre
            {
                Name = "Fighting"
            };
            await _applicationContext.Genres.AddAsync(dbGenre);

            dbGenre = new Genre
            {
                Name = "Platformer"
            };
            await _applicationContext.Genres.AddAsync(dbGenre);

            dbGenre = new Genre
            {
                Name = "Survival"
            };
            await _applicationContext.Genres.AddAsync(dbGenre);

            dbGenre = new Genre
            {
                Name = "Horror"
            };
            await _applicationContext.Genres.AddAsync(dbGenre);

            dbGenre = new Genre
            {
                Name = "Puzzle"
            };
            await _applicationContext.Genres.AddAsync(dbGenre);

            dbGenre = new Genre
            {
                Name = "Action"
            };
            await _applicationContext.Genres.AddAsync(dbGenre);



            await _applicationContext.SaveChangesAsync();
        }
    }
}
