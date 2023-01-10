using System.ComponentModel.DataAnnotations;

namespace SwapMeAngularAuthAPI.Models
{
    public class Transactions
    {
        [Key]
        public int TransactionId { get; set; }
        public int BuyerId { get; set; }
        public DateTime EndedOn { get; set; }

        public int OfferId { get; set; }
    }
}
