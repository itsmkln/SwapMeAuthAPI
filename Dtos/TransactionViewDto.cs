namespace SwapMeAngularAuthAPI.Dtos
{
    public class TransactionViewDto
    {
        public int TransactionId { get; set; }
        public int SellerId { get; set; }
        public string SellerUsername { get; set; } = string.Empty;
        public string SellerFirstName { get; set; } = string.Empty;
        public string SellerLastName { get; set; } = string.Empty;
        public string SellerEmail { get; set; } = string.Empty;
        public string SellerCity { get; set; } = string.Empty;
        public string SellerState { get; set; } = string.Empty;
        public string SellerPhoneNumber { get; set; } = string.Empty;

        public int BuyerId { get; set; }
        public string BuyerUsername { get; set; } = string.Empty;
        public string BuyerFirstName { get; set; } = string.Empty;
        public string BuyerLastName { get; set; } = string.Empty;
        public string BuyerEmail { get; set; } = string.Empty;
        public string BuyerCity { get; set; } = string.Empty;
        public string BuyerState { get; set;} = string.Empty;
        public string BuyerPhoneNumber { get; set; } = string.Empty;

        public int OfferId { get; set; }
        public string GameName { get; set; } = string.Empty;

        public string PlatformName { get; set; } = string.Empty;

        public string OfferTypeName { get; set; } = string.Empty;

        public string OfferDescription { get; set;} = string.Empty;


    }
}
