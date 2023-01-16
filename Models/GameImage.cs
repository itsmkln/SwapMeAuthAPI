using System.ComponentModel.DataAnnotations;

namespace SwapMeAngularAuthAPI.Models
{
    public class GameImage
    {
        [Key]
        public int ImageId { get; set; }
        public byte[] Image { get; set; }
        public int GameId { get; set; }
    }
}
