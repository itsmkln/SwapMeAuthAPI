using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SwapMeAngularAuthAPI.Context;
using SwapMeAngularAuthAPI.Dtos;
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
    public class UsersController : ControllerBase
    {
        private readonly UsersDbContext _usersContext;
        public UsersController(UsersDbContext appDbContext)
        {
            _usersContext = appDbContext;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserDto userObj)
        {
            if (userObj == null)
                return BadRequest();

            var user = await _usersContext.Users
                .Include(u => u.UserInfo)
                .FirstOrDefaultAsync(x => x.Username == userObj.Username);


            if (user == null)
                return NotFound(new {Message = "User not found!"});

            if(!PwHasher.VerifyPassword(userObj.Password, user.Password))
            {
                return BadRequest(new {Message = "Password is invalid"});
            }

            var token = CreateJwtToken(user);
            var username = user.Username;

            return Ok(new
            {
                token,
                username,
                Message = "Login success!"
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDto userObj)
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

            var dbUser = new User
            {
                Username = userObj.Username,
                Password = PwHasher.HashPw(userObj.Password),
                Role = "User",
                Email = userObj.Email,
                UserInfo = new UserInfo
                {
                    FirstName= userObj.FirstName,
                    LastName= userObj.LastName,
                    PhoneNumber= userObj.PhoneNumber,
                    State= userObj.State,
                    City= userObj.City, 
                }
            };

            ////Check if the password is strong
            //var pass = CheckPasswordStrength(userObj.Password);
            //if (!string.IsNullOrEmpty(pass))
            //    return BadRequest(new { Message = pass.ToString() });


            await _usersContext.Users.AddAsync(dbUser);
            await _usersContext.SaveChangesAsync();
            return Ok(new 
            {
                Message = "User registered!" 
            });
        }

        private Task<bool> CheckIfUsernameExistAsync(string username)
            => _usersContext.Users.AnyAsync(x => x.Username == username);
        private Task<bool> CheckIfEmailExistAsync(string email)
            => _usersContext.Users.AnyAsync(x => x.Email == email);

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
                new Claim(ClaimTypes.Name,$"{user.UserInfo.FirstName} {user.UserInfo.LastName}"),
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


        [HttpGet("getallusersinfo")]
        public async Task<ActionResult<User>> GetAllUsersData()
        {
            var users = await _usersContext.Users.Include(x=>x.UserInfo).ToListAsync();
            return Ok(users);
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetUser([FromRoute] string username)
        {
            var users = await _usersContext.Users.Include(x => x.UserInfo).ToListAsync();
            var user = users.FirstOrDefault(x => x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase));
            if(user == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "User not found"
                });
            }
            return Ok(user);
        }

        [HttpPost("setadmin/{userId}")]
        public async Task<IActionResult> Update([FromRoute] int userId)
        {
            if (userId == 0)
            {
                return NotFound();
            }

            var dbUser = await _usersContext.Users.SingleOrDefaultAsync(x => x.UserId == userId);


            if (dbUser == null)
            {
                return NotFound();
            }

            dbUser.Role = "Admin";
            await _usersContext.SaveChangesAsync();
            return Ok("huj");

        }


        [HttpPut("users/update/user")]
        public async Task<IActionResult> Update([FromBody] User userObj)
        {
            if (userObj == null)
            {
                return BadRequest();
            }
            var dbUser = _usersContext.Users.Include(x => x.UserInfo).FirstOrDefault(x => x.UserId == userObj.UserId);

            if (dbUser == null)
            {
                return NotFound("User not found");
            }

            //dbUser.Password = userObj.Password; //in case someone would not put hash, put hashing
            dbUser.Username = userObj.Username;
            dbUser.Role = userObj.Role;
            dbUser.Email = userObj.Email;
            dbUser.UserInfo = userObj.UserInfo;


            await _usersContext.SaveChangesAsync();

            return Ok("User has been updated!");
        }

        [HttpDelete("delete/{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var user = await _usersContext.Users.Include(x => x.UserInfo).SingleOrDefaultAsync(x => x.UserId == userId);
            if (user == null)
                return NotFound();
            //_authContext.UserInfo.Remove(user.UserInfo);
            _usersContext.Users.Remove(user);

            await _usersContext.SaveChangesAsync();
            return Ok("usunełem");
        }

        [HttpDelete("deleteme/{username}")]
        public async Task<IActionResult> DeleteByUsername(string username)
        {
            var user = await _usersContext.Users.Include(x => x.UserInfo).SingleOrDefaultAsync(x => x.Username == username);
            if (user == null)
                return NotFound();
            //_authContext.UserInfo.Remove(user.UserInfo);
            _usersContext.Users.Remove(user);

            await _usersContext.SaveChangesAsync();
            return Ok("usunełem");
        }
    }
}
