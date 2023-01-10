using System.ComponentModel.DataAnnotations;

namespace SwapMeAngularAuthAPI.Models
{
    public class Games
    {
        [Key]
        public int GameId { get; set; }
        public int Name { get; set; }
        public string Genre { get; set; }
        public byte[] Image { get; set; }
    }
}
