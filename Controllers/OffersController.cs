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
                .Include(o => o.Platform)
                .Include(o => o.OfferType)
                .Include(o => o.Game)
                .Include(o => o.Seller)
                .Include(o => o.Game.Genre)
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
            }).ToList();
            return Ok(viewOffers);

        }



    }
}
