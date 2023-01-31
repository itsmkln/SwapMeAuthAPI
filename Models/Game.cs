using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwapMeAngularAuthAPI.Models
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }
        public int Name { get; set; }



        public virtual GameImage GameImage { get; set; }
        public Genre Genre { get; set; }
    }
}
