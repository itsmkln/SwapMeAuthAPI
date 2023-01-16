﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwapMeAngularAuthAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public string? Email { get; set; }

        public UserInfo UserInfo { get; set; }
    }
}
