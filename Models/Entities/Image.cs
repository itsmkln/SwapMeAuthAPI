using System.ComponentModel.DataAnnotations;

namespace SwapMeAngularAuthAPI.Models.Entities
{
    public class Image
    {
        [Key]
        public int GameImageId { get; set; }
        public byte[]? ImageFile { get; set; }


        public int? GameId { get; set; }
        public Game? Game { get; set; }
    }
}
