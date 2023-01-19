﻿using System.ComponentModel.DataAnnotations;

namespace SwapMeAngularAuthAPI.Models
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        public string GenreName { get; set; }

        public int GameId { get; set; }
    }
}
