﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwapMeAngularAuthAPI.Models
{
    public class UserInfo
    {
        [Key]
        public int UserInfoId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
    }
}
