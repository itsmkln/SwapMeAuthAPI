using Microsoft.AspNetCore.Mvc;
using SwapMeAngularAuthAPI.Handlers;
using SwapMeAngularAuthAPI.Handlers.Required;

namespace SwapMeAngularAuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequiredController : ControllerBase // required controller adds sql data that will likely stay unchanged
    {
        private readonly OfferTypesHandler _offerTypesHandler;
        private readonly RequiredGenresHandler _requiredGenresHandler;
        private readonly RequiredPlatformsHandler _requiredPlatformsHandler;
        private readonly RequiredGamesHandler _requiredGamesHandler;


        public RequiredController (OfferTypesHandler offerTypesHandler, RequiredGenresHandler requiredGenresHandler, RequiredPlatformsHandler requiredPlatformsHandler,
            RequiredGamesHandler requiredGamesHandler)
        {
            _offerTypesHandler = offerTypesHandler;
            _requiredGenresHandler = requiredGenresHandler;
            _requiredPlatformsHandler = requiredPlatformsHandler;
            _requiredGamesHandler = requiredGamesHandler;
        }


        [HttpPost("addRequiredOfferTypes")] //adds sell, exchange, sell/exchange offer types
        public async Task<IActionResult> AddOfferTypes()
        {
            await _offerTypesHandler.AddRequiredOfferTypesAsync();
            return Ok();
        }


        [HttpPost("addRequiredGenres")]
        public async Task<IActionResult> AddRequiredGenres()
        {
            await _requiredGenresHandler.AddRequiredGenresAsync();
            return Ok();
        }

        [HttpPost("addRequiredPlatforms")]
        public async Task<IActionResult> AddRequiredPlatforms()
        {
            await _requiredPlatformsHandler.AddRequiredPlatformsAsync();
            return Ok();
        }


        [HttpPost("addRequiredGames")]
        public async Task<IActionResult> AddRequiredGames()
        {
            await _requiredGamesHandler.AddRequiredGamesAsync();
            return Ok();
        }
    }
}
