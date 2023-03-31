using SwapMeAngularAuthAPI.Context;
using SwapMeAngularAuthAPI.Dtos;
using SwapMeAngularAuthAPI.Models.Entities;

namespace SwapMeAngularAuthAPI.Handlers
{
    public class TransactionsHandler
    {
        private readonly ApplicationDbContext _applicationContext;

        public TransactionsHandler(ApplicationDbContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task HandleTransactionAddAsync(TransactionDto transactionObj)
        {


            var dbTransaction = new Transaction
            {
                BuyerId = transactionObj.BuyerId,
                EndedOn = DateTime.Parse(transactionObj.EndedOn),
                OfferId = transactionObj.OfferId,
            };
            await _applicationContext.Transactions.AddAsync(dbTransaction);
            await _applicationContext.SaveChangesAsync();
        }
    }
}