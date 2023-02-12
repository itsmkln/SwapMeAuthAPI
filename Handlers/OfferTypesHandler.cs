using SwapMeAngularAuthAPI.Context;
using SwapMeAngularAuthAPI.Models.Entities;

namespace SwapMeAngularAuthAPI.Handlers
{
    public class OfferTypesHandler
    {
        private readonly ApplicationDbContext _applicationContext;

        public OfferTypesHandler(ApplicationDbContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public async Task HandleOfferTypesAddAsync(OfferType offerTypeObj)
        {
            var dbOfferType = new OfferType
            {
                Name = offerTypeObj.Name
            };

            await _applicationContext.OfferTypes.AddAsync(dbOfferType);
            await _applicationContext.SaveChangesAsync();
        }
    }
}