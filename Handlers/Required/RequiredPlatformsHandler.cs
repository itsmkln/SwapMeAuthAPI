using SwapMeAngularAuthAPI.Context;
using SwapMeAngularAuthAPI.Models.Entities;

namespace SwapMeAngularAuthAPI.Handlers.Required
{
    public class RequiredPlatformsHandler
    {
        private readonly ApplicationDbContext _applicationContext;

        public RequiredPlatformsHandler(ApplicationDbContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public async Task AddRequiredPlatformsAsync()
        {
            var dbPlatform = new Platform
            {
                Name = "PC"
            };
            await _applicationContext.Platforms.AddAsync(dbPlatform);

            dbPlatform = new Platform
            {
                Name = "XBOX"
            };
            await _applicationContext.Platforms.AddAsync(dbPlatform);

            dbPlatform = new Platform
            {
                Name = "PS5"
            };
            await _applicationContext.Platforms.AddAsync(dbPlatform);

            dbPlatform = new Platform
            {
                Name = "Switch"
            };
            await _applicationContext.Platforms.AddAsync(dbPlatform);

            await _applicationContext.SaveChangesAsync();

        }
    }
}