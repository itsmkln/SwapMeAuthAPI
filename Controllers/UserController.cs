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
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _authContext;
        public UserController(AppDbContext appDbContext)
        {
            _authContext = appDbContext;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserDto userObj)
        {
            if (userObj == null)
                return BadRequest();

            var user = await _authContext.Users
                .Include(u => u.UserInfo)
                .FirstOrDefaultAsync(x => x.Username == userObj.Username);


            if (user == null)
                return NotFound(new {Message = "User not found!"});

            if(!PwHasher.VerifyPassword(userObj.Password, user.Password))
            {
                return BadRequest(new {Message = "Password is invalid"});
            }

            var token = CreateJwtToken(user);

            return Ok(new
            {
                token,
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


            await _authContext.Users.AddAsync(dbUser);
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


        [HttpGet("users/getallusersinfo")]
        public async Task<ActionResult<User>> GetAllUsersData()
        {
            var users = await _authContext.Users.Include(x=>x.UserInfo).ToListAsync();
            return Ok(users);
        }

        [HttpGet("users/{username}")]
        public async Task<IActionResult> GetUser([FromRoute] string username)
        {
            var users = await _authContext.Users.Include(x => x.UserInfo).ToListAsync();
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

        [HttpPost("users/setadmin/{userId}")]
        public async Task<IActionResult> Update([FromRoute] int userId)
        {
            if (userId == 0)
            {
                return BadRequest();
            }

            var dbUser = await _authContext.Users.SingleOrDefaultAsync(x => x.UserId == userId);


            if (dbUser == null)
            {
                return NotFound();
            }

            dbUser.Role = "Admin";
            await _authContext.SaveChangesAsync();
            return Ok("huj");

        }


        //[HttpPut("users/update")]
        //public async Task<IActionResult> Update([FromBody] User userObj)
        //{
        //    if (userObj == null)
        //    {
        //        return BadRequest();
        //    }
        //    var user = _authContext.Users.AsNoTracking().FirstOrDefault(x => x.UserId == userObj.UserId);
        //    if(user == null)
        //    {
        //        return NotFound(new
        //        {
        //            StatusCode = 404,
        //            Message = "User not found"
        //        });
        //    }

        //    _authContext.Entry(userObj).State = EntityState.Modified;
        //    await _authContext.SaveChangesAsync();
        //    return Ok(new
        //    {
        //        StatusCode= 200,
        //        Message = "User has been updated!"
        //    });
        //}

        [HttpDelete("users/delete/{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var user = await _authContext.Users.Include(x => x.UserInfo).SingleOrDefaultAsync(x => x.UserId == userId);
            if (user == null)
                return NotFound();
            //_authContext.UserInfo.Remove(user.UserInfo);
            _authContext.Users.Remove(user);

            await _authContext.SaveChangesAsync();
            return Ok("usunełem");
        }
    }
}
