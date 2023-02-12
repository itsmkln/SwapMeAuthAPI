using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwapMeAngularAuthAPI.Context;
using SwapMeAngularAuthAPI.Dtos;
using SwapMeAngularAuthAPI.Handlers;
using SwapMeAngularAuthAPI.Models.Entities;

namespace SwapMeAngularAuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationContext;
        private readonly PlatformsHandler _platformsHandler;
        private readonly GenresHandler _genresHandler;
        private readonly GamesHandler _gamesHandler;
        private readonly OfferTypesHandler _offerTypesHandler;

        public GamesController(ApplicationDbContext applicationContext, GamesHandler gamesHandler, PlatformsHandler platformsHandler, GenresHandler genresHandler,
            OfferTypesHandler offerTypesHandler) 
        {
            _applicationContext = applicationContext;
            _gamesHandler = gamesHandler;
            _platformsHandler = platformsHandler;
            _genresHandler = genresHandler;
            _offerTypesHandler = offerTypesHandler;
        }


        [HttpPost("addgame")]
        public async Task<IActionResult> AddGame([FromBody] GameDto gameObj)
        {
            if(gameObj == null)
            {
                return BadRequest();
            }

            await _gamesHandler.HandleGameAddAsync(gameObj);

            return Ok();
        }

        [HttpPost("addplatform")]
        public async Task<IActionResult> AddPlatform([FromBody] Platform platformObj)
        {
            if (platformObj == null)
            {
                return BadRequest();
            }

            await _platformsHandler.HandlePlatformAddAsync(platformObj);

            return Ok();
        }

        [HttpPost("addgenre")]
        public async Task<IActionResult> AddGenre([FromBody] Genre genreObj)
        {
            if (genreObj == null)
            {
                return BadRequest();
            }

            await _genresHandler.HandleGenreAddAsync(genreObj);


            return Ok();
        }


        [HttpPost("addoffertype")]
        public async Task<IActionResult> AddOfferType([FromBody] OfferType offerTypeObj)
        {
            if (offerTypeObj == null)
            {
                return BadRequest();
            }

            await _offerTypesHandler.HandleOfferTypesAddAsync(offerTypeObj);

            return Ok();
        }

        //[HttpPost]
        //public async Task<IActionResult> AddGenre([FromBody] GameDto gameObj)
        //{
        //    return Ok();
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddGame([FromBody] GameDto gameObj)
        //{
        //    return Ok();
        //}



    }

    



}
