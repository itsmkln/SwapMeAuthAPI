using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SwapMeAngularAuthAPI.Context;
using SwapMeAngularAuthAPI.Helpers;
using SwapMeAngularAuthAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;

namespace SwapMeAngularAuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _authContext;
        public UserController(AppDbContext appDbContext)
        {
            _authContext = appDbContext;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] User userObj)
        {
            if (userObj == null)
                return BadRequest();
            var user = await _authContext.Users
                .FirstOrDefaultAsync(x=>x.Username == userObj.Username && x.Password == userObj.Password);
            if (user == null)
                return NotFound(new {Message = "Invalid credentials!"});

            user.Token = CreateJwtToken(user);

            return Ok(new
            {
                Token = user.Token,
                Message = "Login success!"
            }) ;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User userObj)
        {
            if(userObj == null)
                return BadRequest();

            //Check if the username already exists
            if (await CheckIfUsernameExistAsync(userObj.Username))
            {
                return BadRequest(new { Message = "Username already exists!" });
            }

            //Check if the email already exists

            if (await CheckIfEmailExistAsync(userObj.Email))
            {
                return BadRequest(new { Message = "Email already exists!" });
            }

            //Check if the password is strong
            var pass = CheckPasswordStrength(userObj.Password);
            if (!string.IsNullOrEmpty(pass))
                return BadRequest(new { Message = pass.ToString() });


            userObj.Password = PwHasher.HashPw(userObj.Password);
            userObj.Role = "User";
            userObj.Token = "";

            await _authContext.Users.AddAsync(userObj);
            await _authContext.SaveChangesAsync();
            return Ok(new 
            {
                Message = "User registered!" 
            });
        }

        private Task<bool> CheckIfUsernameExistAsync(string username)
            => _authContext.Users.AnyAsync(x => x.Username == username);
        private Task<bool> CheckIfEmailExistAsync(string email)
            => _authContext.Users.AnyAsync(x => x.Email == email);

        private string CheckPasswordStrength(string password)
        {
            StringBuilder sb = new();
            if (password.Length < 8)
            {
                sb.Append("- Minimum length of password is 8" + Environment.NewLine);
            }
            if (!(Regex.IsMatch(password, "[a-z]") && Regex.IsMatch(password, "[A-Z]")
                && Regex.IsMatch(password, "[0-9]")))
                sb.Append("- Password should contain lowercase letters, uppercase letters and numbers" + Environment.NewLine);
            if (!Regex.IsMatch(password, "[<,>,!,@,#,$,%,^,&,*,(,),-,_,+,=,[,\\],{,},{,},\\[,\\]|,;,:,',.,?,\\],`,~]"))
                sb.Append("- Password should contain special characters" + Environment.NewLine);
            return sb.ToString();

        }

        private string CreateJwtToken(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("thisissecretkeyasfck2137.//");
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.Name,$"{user.FirstName} {user.LastName}"),
            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetAllUsers()
        {
            return Ok(await _authContext.Users.ToListAsync());
        }
    }
}
