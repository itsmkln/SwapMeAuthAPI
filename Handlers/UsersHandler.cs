using SwapMeAngularAuthAPI.Context;
using SwapMeAngularAuthAPI.Dtos;
using SwapMeAngularAuthAPI.Helpers;
using SwapMeAngularAuthAPI.Models.Entities;

namespace SwapMeAngularAuthAPI.Handlers
{
    public class UsersHandler
    {
        private readonly ApplicationDbContext _applicationContext;

        public UsersHandler(ApplicationDbContext applicationContext)
        {
             _applicationContext = applicationContext;
        }
        public async Task HandleRegistrationAsync(UserDto userObj)
        {
            var dbUser = new User
            {
                Username = userObj.Username,
                Password = PwHasher.HashPw(userObj.Password),
                Role = "User",
                Email = userObj.Email,
                UserInfo = new UserInfo
                {
                    FirstName = userObj.FirstName,
                    LastName = userObj.LastName,
                    PhoneNumber = userObj.PhoneNumber,
                    State = userObj.State,
                    City = userObj.City,
                }
            };

            ////Check if the password is strong
            //var pass = CheckPasswordStrength(userObj.Password);
            //if (!string.IsNullOrEmpty(pass))
            //    return BadRequest(new { Message = pass.ToString() });


            await _applicationContext.Users.AddAsync(dbUser);
            await _applicationContext.SaveChangesAsync();
        }
    }
}
