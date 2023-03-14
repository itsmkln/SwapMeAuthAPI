using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwapMeAngularAuthAPI.Models.Entities
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }
        public string Name { get; set; }


        public Image? Image { get; set; }
        public Genre Genre { get; set; }
        public int? GenreId { get; set; }
        public List<Offer>? Offers { get; set; } = new List<Offer>();
    }
}
