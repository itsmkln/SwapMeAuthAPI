namespace SwapMeAngularAuthAPI.Dtos
{
    public class OfferUpdateDto
    {
        public int OfferId { get; set; }
        public double Price { get; set; } = 0;
        public string OfferDescription { get; set; } = string.Empty;
        public int OfferTypeId { get; set; } //ex. 1-sell, 2-exchange, 3-both
    }
}
