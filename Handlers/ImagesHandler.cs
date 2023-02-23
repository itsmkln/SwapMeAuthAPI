using SwapMeAngularAuthAPI.Context;
using SwapMeAngularAuthAPI.Dtos;
using SwapMeAngularAuthAPI.Models.Entities;

namespace SwapMeAngularAuthAPI.Handlers
{
    public class ImagesHandler
    {
        private readonly ApplicationDbContext _applicationContext;

        public ImagesHandler(ApplicationDbContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public async Task HandleImageAddAsync(Image imageObj)
        {
            var dbImage = new Image
            {
                ImageFile = imageObj.ImageFile
            };

            await _applicationContext.Images.AddAsync(dbImage);
            await _applicationContext.SaveChangesAsync();
        }
    }
}
