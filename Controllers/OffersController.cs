using Microsoft.AspNetCore.Mvc;
using SwapMeAngularAuthAPI.Context;
using SwapMeAngularAuthAPI.Dtos;
using SwapMeAngularAuthAPI.Handlers;

namespace SwapMeAngularAuthAPI.Controllers
{
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
            await _offersHandler.HandleOfferAddAsync(offerObj);
            return Ok();
        }

    }
}
