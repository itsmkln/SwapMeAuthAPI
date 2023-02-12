using System.ComponentModel.DataAnnotations;

namespace SwapMeAngularAuthAPI.Models.Entities
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        public string Name { get; set; }

        public Game? Game { get; set; }
        public int? GameId { get; set; }
    }
}
