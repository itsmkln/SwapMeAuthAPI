using System.ComponentModel.DataAnnotations;

namespace SwapMeAngularAuthAPI.Models.Entities
{
    public class OfferType
    {
        [Key]
        public int OfferTypeId { get; set; }
        public string Name { get; set; }

        public List<Offer>? Offers { get; set; } = new List<Offer>();

    }
}
