using SwapMeAngularAuthAPI.Context;
using SwapMeAngularAuthAPI.Dtos;
using SwapMeAngularAuthAPI.Helpers;
using SwapMeAngularAuthAPI.Models;

namespace SwapMeAngularAuthAPI.Handlers
{
    public class TransactionsHandler
    {
        private readonly UsersDbContext _transactionsContext;

        public TransactionsHandler(TransactionsDbContext transactionsContext)
        {
             _transactionsContext = transactionsContext;
        }
        public async Task HandleTradeAsync(TransactionDto tradeDto)
        {
            var dbTransaction = new Transaction
            {



            await _transactionsContext.Transactions.AddAsync(dbTransaction);
            await _transactionsContext.SaveChangesAsync();
        }
    }
}
