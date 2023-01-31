using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwapMeAngularAuthAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set;} = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty; 
        public string Email { get; set; } = string.Empty;

        public virtual UserInfo UserInfo { get; set; } = new UserInfo();
        public virtual Offer Offer { get; set; } = new Offer();
    }
}
