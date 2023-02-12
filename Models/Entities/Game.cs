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
        public Genre? Genre { get; set; }
    }
}
