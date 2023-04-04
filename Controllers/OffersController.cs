using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwapMeAngularAuthAPI.Context;
using SwapMeAngularAuthAPI.Dtos;
using SwapMeAngularAuthAPI.Handlers;
using SwapMeAngularAuthAPI.Models.Entities;
using System.Net;
using System.Security.Cryptography;

namespace SwapMeAngularAuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationContext;
        private readonly OffersHandler _offersHandler;
        public OffersController(ApplicationDbContext applicationContext, OffersHandler offersHandler) 
        {
            _applicationContext = applicationContext;
            _offersHandler = offersHandler;
        }

        [HttpPost("addOffer")]
        public async Task<IActionResult> AddOffer([FromBody] OfferDto offerObj)
        {
            if(offerObj == null)
            {
                return BadRequest();
            }

            await _offersHandler.HandleOfferAddAsync(offerObj);
            return Ok();
        }

        [HttpGet("getOffers")]
        public async Task<ActionResult<OfferViewDto>> GetOffers()
        {
            var offers = await _applicationContext.Offers
                .Where(o => o.Status == "Active")
                .Include(o => o.Platform)
                .Include(o => o.OfferType)
                .Include(o => o.Game)
                .Include(o => o.Seller)
                .Include(o => o.Game.Genre)
                .Include(o => o.Seller.UserInfo)
                .ToListAsync();

            var viewOffers = offers.Select(o => new OfferViewDto()
            {
                OfferId = o.OfferId,
                IsPhysical = o.IsPhysical,
                CreatedOn = o.CreatedOn,
                Price = o.Price,
                Status = o.Status,

                GameId = o.GameId,
                SellerId = o.SellerId,
                Description = o.Description,


                GameName = o.Game.Name,
                GenreName = o.Game.Genre.Name,
                PlatformName = o.Platform.Name,
                SellerName = o.Seller.Username,
                OfferTypeName = o.OfferType.Name,
                SellerCity = o.Seller.UserInfo.City,
                SellerState = o.Seller.UserInfo.State,
            }).ToList();

            return Ok(viewOffers);

        }


        [HttpGet("/{offerId}")]
        public async Task<ActionResult<OfferViewDto>> GetOfferInfo([FromRoute]int offerId)
        {
            var offer = await _applicationContext.Offers
                .Include(o => o.Platform)
                .Include(o => o.OfferType)
                .Include(o => o.Game)
                .Include(o => o.Seller)
                .Include(o => o.Seller.UserInfo)
                .Include(o => o.Game.Genre)
                .Select(o => new OfferViewDto() {
                    OfferId = o.OfferId,
                    IsPhysical = o.IsPhysical,
                    CreatedOn = o.CreatedOn,
                    Price = o.Price,
                    Status = o.Status,

                    GameId = o.GameId,
                    SellerId = o.SellerId,
                    Description = o.Description,


                    GameName = o.Game.Name,
                    GenreName = o.Game.Genre.Name,
                    PlatformName = o.Platform.Name,
                    SellerName = o.Seller.Username,
                    OfferTypeName = o.OfferType.Name,
                    SellerCity = o.Seller.UserInfo.City,
                    SellerState = o.Seller.UserInfo.State,
                })
                .FirstOrDefaultAsync(x => x.OfferId == offerId);




            return Ok(offer);
        }

        [HttpPost("statusUpdate")]
        public async Task<IActionResult> Update(OfferStatusUpdateDto statusObj)
        {
            if (statusObj == null)
            {
                return BadRequest();
            }
            var dbOffer = await _applicationContext.Offers.FirstOrDefaultAsync(x => x.OfferId == statusObj.OfferId);

            if (dbOffer != null)
            {
                dbOffer.Status = statusObj.Status;
                await _applicationContext.SaveChangesAsync();

                return Ok(new
                {
                    Message = "Offer status has been updated."
                });
            }
            return NotFound("Offer not found");

        }

        [HttpGet("getActiveOffers/{sellerId}")]
        public async Task<ActionResult<MyOffersDto>> GetActiveOffersInfo([FromRoute] int sellerId)
        {
            var offers = await _applicationContext.Offers
                .Where(o => o.SellerId == sellerId)
                .Where(o => o.Status == "Active")
                .Include(o => o.Transaction)
                .Include(o => o.Transaction.Buyer)
                .Include(o => o.Transaction.Buyer.UserInfo)
                .Include(o => o.Seller)
                .Include(o => o.Seller.UserInfo)
                .Include(o => o.Game)
                .Include(o => o.Platform)
                .Include(o => o.OfferType)

                .Select(o => new MyOffersDto()

                {
                    OfferId = o.OfferId,
                    SellerId = o.SellerId,
                    SellerUsername = o.Seller.Username,
                    SellerFirstName = o.Seller.UserInfo.FirstName,
                    SellerLastName = o.Seller.UserInfo.LastName,
                    SellerEmail = o.Seller.Email,
                    SellerCity = o.Seller.UserInfo.City,
                    SellerPhoneNumber = o.Seller.UserInfo.PhoneNumber,

                    GameName = o.Game.Name,
                    PlatformName = o.Platform.Name,
                    OfferTypeName = o.OfferType.Name,
                    OfferDescription = o.Description,
                    Status = o.Status,
                    CreatedOn = o.CreatedOn,
                })
                .ToListAsync();
            return Ok(offers);
        }

        [HttpGet("getEndedOffers/{sellerId}")]
        public async Task<ActionResult<TransactionViewDto>> GetEndedOffersInfo([FromRoute] int sellerId)
        {
            var offers = await _applicationContext.Offers
                .Where(o => o.SellerId == sellerId)
                .Where(o => o.Status == "Ended")
                .Include(o => o.Transaction)
                .Include(o => o.Transaction.Buyer)
                .Include(o => o.Transaction.Buyer.UserInfo)
                .Include(o => o.Seller)
                .Include(o => o.Seller.UserInfo)
                .Include(o => o.Game)
                .Include(o => o.Platform)
                .Include(o => o.OfferType)

                .Select(o => new TransactionViewDto()

                {
                    TransactionId = o.Transaction.TransactionId,
                    SellerId = o.SellerId,
                    SellerUsername = o.Seller.Username,
                    SellerFirstName = o.Seller.UserInfo.FirstName,
                    SellerLastName = o.Seller.UserInfo.LastName,
                    SellerEmail = o.Seller.Email,
                    SellerCity = o.Seller.UserInfo.City,
                    SellerPhoneNumber = o.Seller.UserInfo.PhoneNumber,

                    BuyerId = o.Transaction.BuyerId,
                    BuyerUsername = o.Transaction.Buyer.Username,
                    BuyerFirstName = o.Transaction.Buyer.UserInfo.FirstName,
                    BuyerLastName = o.Transaction.Buyer.UserInfo.LastName,
                    BuyerEmail = o.Transaction.Buyer.UserInfo.User.Email,
                    BuyerCity = o.Transaction.Buyer.UserInfo.City,
                    BuyerState = o.Transaction.Buyer.UserInfo.State,
                    BuyerPhoneNumber = o.Transaction.Buyer.UserInfo.PhoneNumber,

                    OfferId = o.OfferId,
                    GameName = o.Game.Name,
                    PlatformName = o.Platform.Name,
                    OfferTypeName = o.OfferType.Name,
                    OfferDescription = o.Description,
                    Status = o.Status,
                    CreatedOn = o.CreatedOn,
                    EndedOn = o.Transaction.EndedOn,
                })
                .ToListAsync();
            return Ok(offers);
        }

        [HttpDelete("deleteOfferById/{offerId}")]
        public async Task<IActionResult> DeleteOffer(int offerId)
        {
            var offer = await _applicationContext.Offers.FirstOrDefaultAsync(o => o.OfferId == offerId);
            if (offer == null)
                return NotFound();

            _applicationContext.Offers.Remove(offer);
            await _applicationContext.SaveChangesAsync();
            return Ok(new
            {
                Message = "Offer has been deleted."
            });
        }



    }
}
