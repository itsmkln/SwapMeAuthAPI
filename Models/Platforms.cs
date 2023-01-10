using System.ComponentModel.DataAnnotations;

namespace SwapMeAngularAuthAPI.Models
{
    public class Platforms
    {
        [Key]
        public int PlatformId { get; set; }
        public string Name { get; set; }

    }
}
