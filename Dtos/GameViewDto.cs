using SwapMeAngularAuthAPI.Models.Entities;

namespace SwapMeAngularAuthAPI.Dtos
{
    public class GameViewDto
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public string GenreName { get; set; }

        //public byte[]? ImageFile { get; set; }
    }
}
