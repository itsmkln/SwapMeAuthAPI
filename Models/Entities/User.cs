using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwapMeAngularAuthAPI.Models.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public UserInfo UserInfo { get; set; } = new UserInfo();
        public int UserInfoId { get; set; }
        public List<Offer>? Offers { get; set; }
        public List<Transaction>? Transactions { get; set; }

    }
}
