using SwapMeAngularAuthAPI.Models;

namespace SwapMeAngularAuthAPI.Dtos
{
    public class TransactionDto
    {
        public int TransactionId { get; set; }
        public int BuyerId { get; set; }
        public DateTime EndedOn { get; set; }

        public int OfferId;
    }
}
