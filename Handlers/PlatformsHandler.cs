using SwapMeAngularAuthAPI.Context;
using SwapMeAngularAuthAPI.Dtos;
using SwapMeAngularAuthAPI.Models.Entities;

namespace SwapMeAngularAuthAPI.Handlers
{
    public class PlatformsHandler
    {
        private readonly ApplicationDbContext _applicationContext;

        public PlatformsHandler(ApplicationDbContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public async Task HandlePlatformAddAsync(Platform platformObj)
        {
            var dbPlatform = new Platform
            {
                Name = platformObj.Name
            };

            await _applicationContext.Platforms.AddAsync(dbPlatform);
            await _applicationContext.SaveChangesAsync();
        }
    }
}
