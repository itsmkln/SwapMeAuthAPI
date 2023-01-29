namespace SwapMeAngularAuthAPI.Dtos
{
    public class GameDto
    {
        public int GameId { get; set; }
        public int Name { get; set; }

        public byte[]? Image { get; set; }
        public string PlatformName { get; set; }
        public string GenreName { get; set; }

    }
}
