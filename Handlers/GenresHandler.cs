using SwapMeAngularAuthAPI.Context;
using SwapMeAngularAuthAPI.Dtos;
using SwapMeAngularAuthAPI.Models.Entities;

namespace SwapMeAngularAuthAPI.Handlers
{
    public class GenresHandler
    {
        private readonly ApplicationDbContext _applicationContext;

        public GenresHandler(ApplicationDbContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public async Task HandleGenreAddAsync(Genre genreObj)
        {
            var dbGenre = new Genre
            {
                Name = genreObj.Name
            };

            await _applicationContext.Genres.AddAsync(dbGenre);
            await _applicationContext.SaveChangesAsync();
        }
    }
}
