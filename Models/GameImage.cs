using System.ComponentModel.DataAnnotations;

namespace SwapMeAngularAuthAPI.Models
{
    public class GameImage
    {
        [Key]
        public int GameImageId { get; set; }
        public byte[] Image { get; set; }
    }
}
