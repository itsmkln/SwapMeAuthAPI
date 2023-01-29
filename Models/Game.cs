using System.ComponentModel.DataAnnotations;

namespace SwapMeAngularAuthAPI.Models
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }
        public int Name { get; set; }


        public Platform Platform { get; set; }
        public GameImage GameImage { get; set; }
        public Genre Genre { get; set; }
        public Offer Offer { get; set; }
    }
}
