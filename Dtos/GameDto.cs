namespace SwapMeAngularAuthAPI.Dtos
{
    public class GameDto
    {
        public int GameId { get; set; }
        public string Name { get; set; }

        
        public byte[]? ImageFile { get; set; }
        public string? PlatformName { get; set; }
        public string? GenreName { get; set; }

    }
}
