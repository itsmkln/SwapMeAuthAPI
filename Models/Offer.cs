using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace SwapMeAngularAuthAPI.Models
{
    public class Offer
    {
        [Key]
        public int OfferId { get; set; }
        public int SellerId { get; set; }
        public bool isPhysical { get; set; } // is product in box or digital
        public int PlatformId { get; set; }
        public string OfferType { get; set; } // xchange, sale, xchange+sale
        public DateTime CreatedOn { get; set; }
        public double Price { get; set; }
        public string Status { get; set; } // new/active/ended/sold


        public int GameId { get; set; }
    }
}
