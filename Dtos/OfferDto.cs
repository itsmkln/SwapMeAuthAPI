namespace SwapMeAngularAuthAPI.Dtos
{
    public class OfferDto
    {
        public int OfferId { get; set; }
        public bool IsPhysical { get; set; } = false; //default = digital
        public DateTime CreatedOn { get; set; } = DateTime.MinValue;
        public double? Price { get; set; } = 0;
        public string Status { get; set; } = "new"; //new/active/ended/sold
        public int OfferTypeId { get; set; } //1-sell, 2-exchange, 3-both
        public int PlatformId { get; set; }
        public int GameId { get; set; }
        public int SellerId { get; set; }
    }
}
