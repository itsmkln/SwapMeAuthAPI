using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using SwapMeAngularAuthAPI.Context;
using SwapMeAngularAuthAPI.Dtos;
using SwapMeAngularAuthAPI.Handlers;
using SwapMeAngularAuthAPI.Models.Entities;
using System.Net.Http;
using System.Web;

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
        //private readonly ImagesHandler _imagesHandler;

        public GamesController(ApplicationDbContext applicationContext, GamesHandler gamesHandler, PlatformsHandler platformsHandler, GenresHandler genresHandler)
            //ImagesHandler imagesHandler) 
        {
            _applicationContext = applicationContext;
            _gamesHandler = gamesHandler;
            _platformsHandler = platformsHandler;
            _genresHandler = genresHandler;
           // _imagesHandler = imagesHandler;

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

        [HttpGet("getAllGames")]
        public async Task<ActionResult<Game>> GetAllGamesData()
        {
            var games = await _applicationContext.Games.ToListAsync();
            return Ok(games);
        }

        [HttpGet("getAllGenres")]
        public async Task<ActionResult<Genre>> GetAllGenres()
        {
            var genres = await _applicationContext.Genres.ToListAsync();
            return Ok(genres);
        }

        [HttpGet("getPlatforms")]
        public async Task<ActionResult<Platform>> GetPlatforms()
        {
            var platforms = await _applicationContext.Platforms.ToListAsync();
            return Ok(platforms);
        }

        [HttpGet("getOfferTypes")]
        public async Task<ActionResult<Platform>> GetOfferTypes()
        {
            var offerTypes = await _applicationContext.OfferTypes.ToListAsync();
            return Ok(offerTypes);
        }





        //[HttpPost("addimage")]
        //public async Task<IActionResult> AddImage([FromBody] Image imageObj)
        //{
        //    if (imageObj == null)
        //    {
        //        return BadRequest();
        //    }

        //    foreach (var file in Request.Form.Files)
        //    {
        //        Image img = new Image();


        //        MemoryStream ms = new MemoryStream();
        //        file.CopyTo(ms);
        //        img.ImageFile = ms.ToArray();

        //        ms.Close();
        //        ms.Dispose();

        //        await _imagesHandler.HandleImageAddAsync(img);

        //    }
        //    return Ok();


        //}



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
