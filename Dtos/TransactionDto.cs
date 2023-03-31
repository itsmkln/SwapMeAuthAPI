using SwapMeAngularAuthAPI.Models;

namespace SwapMeAngularAuthAPI.Dtos
{
    public class TransactionDto
    {
        public int TransactionId { get; set; }
        public int BuyerId { get; set; }
        public string EndedOn { get; set; } = string.Empty;

        public int OfferId { get; set; }
    }
}
