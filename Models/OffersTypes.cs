﻿using System.ComponentModel.DataAnnotations;

namespace SwapMeAngularAuthAPI.Models
{
    public class OffersTypes
    {
        [Key]
        public int OfferTypeId { get; set; }
        public string Name { get; set; }
    }
}
