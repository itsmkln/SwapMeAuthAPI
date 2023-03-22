using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwapMeAngularAuthAPI.Context;
using SwapMeAngularAuthAPI.Dtos;
using SwapMeAngularAuthAPI.Handlers;

namespace SwapMeAngularAuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationContext;
        private readonly TransactionsHandler _transactionsHandler;
        public TransactionsController(ApplicationDbContext applicationContext, TransactionsHandler transactionsHandler)
        {
            _applicationContext = applicationContext;
            _transactionsHandler = transactionsHandler;
        }


        [HttpPost("addTransaction")]
        public async Task<IActionResult> AddOffer([FromBody] TransactionDto transactionObj)
        {
            if (transactionObj == null)
            {
                return BadRequest();
            }

            await _transactionsHandler.HandleOfferAddAsync(transactionObj);
            return Ok();
        }

        [HttpGet("getTransactions")]
        public async Task<ActionResult<TransactionDto>> GetTransactions()
        {
            var transactions = await _applicationContext.Transactions
                .ToListAsync();
            return Ok(transactions);

        }

        [HttpGet("getTransactionsView")]
        public async Task<ActionResult<TransactionViewDto>> GetTransactionsView()
        {
            var transactions = await _applicationContext.Transactions
                //.Include(o => o.Platform) add needed includes of viewdto
                .ToListAsync();

            var viewOffers = transactions.Select(t => new TransactionViewDto()
            {
                TransactionId = t.TransactionId,
                //add more transactionview properties

            }).ToList();
            return Ok(viewOffers);

        }

    }
}
