namespace SwapMeAngularAuthAPI.Dtos
{
    public class OfferViewDto
    {
        public int OfferId { get; set; }
        public bool IsPhysical { get; set; } = false; //default = digital
        public DateTime CreatedOn { get; set; }
        public double? Price { get; set; } = 0;
        public string Status { get; set; } = "New"; //new/active/ended/sold

        public int GameId { get; set; }
        public int SellerId { get; set; }
        public string? Description { get; set; }

        public string GameName { get; set; } = string.Empty;
        public string GenreName { get; set; } = string.Empty;
        public string PlatformName { get; set; } = string.Empty;   
        public string SellerName { get; set; } = string.Empty;
        public string OfferTypeName { get; set; } = string.Empty; //ex. 1-sell, 2-exchange, 3-both

    }
}
