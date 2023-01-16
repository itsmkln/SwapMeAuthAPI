using System.ComponentModel.DataAnnotations;

namespace SwapMeAngularAuthAPI.Models
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }
        public int Name { get; set; }
        public string Genre { get; set; }
    }
}
