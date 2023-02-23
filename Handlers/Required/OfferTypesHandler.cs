using SwapMeAngularAuthAPI.Context;
using SwapMeAngularAuthAPI.Models.Entities;

namespace SwapMeAngularAuthAPI.Handlers.Required
{
    public class OfferTypesHandler
    {
        private readonly ApplicationDbContext _applicationContext;

        public OfferTypesHandler(ApplicationDbContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public async Task AddRequiredOfferTypesAsync()
        {
            var dbOfferType = new OfferType
            {
                Name = "Sell"
            };

            await _applicationContext.OfferTypes.AddAsync(dbOfferType);

            dbOfferType = new OfferType
            {
                Name = "Exchange"
            };

            await _applicationContext.OfferTypes.AddAsync(dbOfferType);

            dbOfferType = new OfferType
            {
                Name = "Sell or exchange"
            };

            await _applicationContext.OfferTypes.AddAsync(dbOfferType);
            await _applicationContext.SaveChangesAsync();

        }
    }
}