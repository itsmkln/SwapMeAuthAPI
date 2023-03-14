using System.ComponentModel.DataAnnotations;

namespace SwapMeAngularAuthAPI.Models.Entities
{
    public class Platform
    {
        [Key]
        public int PlatformId { get; set; }
        public string Name { get; set; }

        public List<Offer>? Offers { get; set; } = new List<Offer>();
    }
}
