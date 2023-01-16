using System.ComponentModel.DataAnnotations;

namespace SwapMeAngularAuthAPI.Models
{
    public class OfferType
    {
        [Key]
        public int OfferTypeId { get; set; }
        public string Name { get; set; }
    }
}
