using System.ComponentModel.DataAnnotations;

namespace SwapMeAngularAuthAPI.Models
{
    public class Platform
    {
        [Key]
        public int PlatformId { get; set; }
        public string Name { get; set; }

        public int OfferId { get; set; }
    }
}
