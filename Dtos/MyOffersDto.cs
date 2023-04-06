namespace SwapMeAngularAuthAPI.Dtos
{
    public class MyOffersDto
    {
        public int OfferId { get; set; }
        public int SellerId { get; set; }
        public string SellerUsername { get; set; } = string.Empty;
        public string SellerFirstName { get; set; } = string.Empty;
        public string SellerLastName { get; set; } = string.Empty;
        public string SellerEmail { get; set; } = string.Empty;
        public string SellerCity { get; set; } = string.Empty;
        public string SellerState { get; set; } = string.Empty;
        public string SellerPhoneNumber { get; set; } = string.Empty;

        public string GameName { get; set; } = string.Empty;

        public string PlatformName { get; set; } = string.Empty;

        public string OfferTypeName { get; set; } = string.Empty;
        public int OfferTypeId { get; set; } = 0;

        public string OfferDescription { get; set; } = string.Empty;
        public string Status { get; set;} = string.Empty;
        public double Price { get; set; } = 0;

        public DateTime CreatedOn { get; set; } = DateTime.MinValue;

    }
}
