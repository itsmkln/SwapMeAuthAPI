using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwapMeAngularAuthAPI.Models.Entities
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public DateTime EndedOn { get; set; }
        public string Status { get; set; }


        public Offer? Offer { get; set; }
        public int? OfferId { get; set; }

        public User Buyer { get; set; }
        public int BuyerId { get; set; }

    }
}
