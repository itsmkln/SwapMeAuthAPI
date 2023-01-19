using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwapMeAngularAuthAPI.Context;
using SwapMeAngularAuthAPI.Dtos;
using SwapMeAngularAuthAPI.Models;

namespace SwapMeAngularAuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly GamesDbContext _gamesContext;

        public GamesController(GamesDbContext gamesDbContext) 
        {
            _gamesContext = gamesDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddGame(GameDto game)
        {
            return Ok();
        }



    }

    



}
