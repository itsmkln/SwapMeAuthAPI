namespace SwapMeAngularAuthAPI.Dtos
{
    public class OfferDto
    {
        public int OfferId { get; set; }
        public bool IsPhysical { get; set; } = false; //default = digital
        public string CreatedOn { get; set; } = "";
        public double Price { get; set; } = 0;
        public string Status { get; set; } = "Active"; //active/ended
        public string Description { get; set; } = string.Empty;
        public int OfferTypeId { get; set; } //ex. 1-sell, 2-exchange, 3-both
        public int PlatformId { get; set; }
        public int GameId { get; set; }
        public int SellerId { get; set; }
    }
}
