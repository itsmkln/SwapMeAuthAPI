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
        public async Task<ActionResult<TransactionUserViewDto>> GetTransactionsView()
        {
            var transactions = await _applicationContext.Transactions
                .Include(t => t.Offer)
                
                //.Include(o => o.Platform) add needed includes of viewdto
                .ToListAsync();

            var viewOffers = transactions.Select(t => new TransactionUserViewDto()
            {
                TransactionId = t.TransactionId,
                SellerId = t.Offer.SellerId,
                SellerUsername = t.Offer.Seller.Username,
                SellerFirstName = t.Offer.Seller.UserInfo.FirstName,
                SellerLastName = t.Offer.Seller.UserInfo.LastName,
                SellerEmail = t.Offer.Seller.UserInfo.User.Email,
                SellerCity = t.Offer.Seller.UserInfo.City,
                SellerPhoneNumber = t.Offer.Seller.UserInfo.PhoneNumber,

                BuyerId = t.BuyerId,
                BuyerUsername = t.Buyer.Username,
                BuyerFirstName = t.Buyer.UserInfo.FirstName,
                BuyerLastName = t.Buyer.UserInfo.LastName,
                BuyerEmail = t.Buyer.UserInfo.User.Email,
                BuyerCity = t.Buyer.UserInfo.City,
                BuyerState = t.Buyer.UserInfo.State,
                BuyerPhoneNumber = t.Buyer.UserInfo.PhoneNumber,

                OfferId = t.Offer.OfferId,
                GameName = t.Offer.Game.Name,
                PlatformName = t.Offer.Platform.Name,
                OfferTypeName = t.Offer.OfferType.Name,
                OfferDescription = t.Offer.Description

                //add more transactionview properties

            }).ToList();
            return Ok(viewOffers);

        }

    }
}
