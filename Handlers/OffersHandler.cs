using SwapMeAngularAuthAPI.Context;
using SwapMeAngularAuthAPI.Dtos;
using SwapMeAngularAuthAPI.Models.Entities;

namespace SwapMeAngularAuthAPI.Handlers
{
    public class OffersHandler
    {
        private readonly ApplicationDbContext _applicationContext;

        public OffersHandler(ApplicationDbContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task HandleOfferAddAsync(OfferDto offerObj)
        {
            var dbOffer = new Offer
            {
                IsPhysical = offerObj.IsPhysical,
                CreatedOn = offerObj.CreatedOn,
                Price = (double)offerObj.Price,
                Status = offerObj.Status,
                OfferTypeId = offerObj.OfferTypeId,
                PlatformId = offerObj.PlatformId,
                GameId = offerObj.GameId,
                SellerId = offerObj.SellerId,
            };
            await _applicationContext.Offers.AddAsync(dbOffer);
            await _applicationContext.SaveChangesAsync();
        }
    }
}
