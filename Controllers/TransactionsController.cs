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
        public async Task<IActionResult> AddOffer(TransactionDto transactionObj)
        {
            if (transactionObj == null)
            {
                return BadRequest();
            }

            await _transactionsHandler.HandleTransactionAddAsync(transactionObj);
            return Ok();
        }

        [HttpGet("getTransactions")]
        public async Task<ActionResult<TransactionDto>> GetTransactions()
        {
            var transactions = await _applicationContext.Transactions
                .ToListAsync();
            return Ok(transactions);

        }

        [HttpGet("getTransactionsView/{userId}")]
        public async Task<ActionResult<TransactionViewDto>> GetTransactionsView([FromRoute] int userId)
        {
            var transactions = await _applicationContext.Transactions
                .Where(t => t.Offer.SellerId == userId || (t.BuyerId == userId))
                .Include(t => t.Offer)
                .Include(t => t.Buyer)
                .Include(t => t.Buyer.UserInfo)
                .Include(t => t.Offer.Seller)
                .Include(t => t.Offer.Seller.UserInfo)
                .Include(t => t.Offer.Game)
                .Include(t => t.Offer.Platform)
                .Include(t => t.Offer.OfferType)


                //.Include(o => o.Platform) add needed includes of viewdto
                .ToListAsync();

            var viewTransactions = transactions.Select(t => new TransactionViewDto()
            {
                TransactionId = t.TransactionId,
                SellerId = t.Offer.SellerId,
                SellerUsername = t.Offer.Seller.Username,
                SellerFirstName = t.Offer.Seller.UserInfo.FirstName,
                SellerLastName = t.Offer.Seller.UserInfo.LastName,
                SellerEmail = t.Offer.Seller.Email,
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
                OfferDescription = t.Offer.Description,
                Status = t.Offer.Status,
                CreatedOn = t.Offer.CreatedOn,
                EndedOn = t.EndedOn,

                //add more transactionview properties

            }).ToList();
            return Ok(viewTransactions);

        }


        [HttpGet("getBuyerView/{buyerId}")]
        public async Task<ActionResult<TransactionViewDto>> GetTransactionsInfo([FromRoute] int buyerId)
        {
            var transaction = await _applicationContext.Transactions
                .Where(t => t.BuyerId == buyerId)
                .Include(t => t.Offer)
                .Include(t => t.Buyer)
                .Include(t => t.Buyer.UserInfo)
                .Include(t => t.Offer.Seller)
                .Include(t => t.Offer.Seller.UserInfo)
                .Include(t => t.Offer.Game)
                .Include(t => t.Offer.Platform)
                .Include(t => t.Offer.OfferType)

                .Select(t => new TransactionViewDto()

                {
                    TransactionId = t.TransactionId,
                    SellerId = t.Offer.SellerId,
                    SellerUsername = t.Offer.Seller.Username,
                    SellerFirstName = t.Offer.Seller.UserInfo.FirstName,
                    SellerLastName = t.Offer.Seller.UserInfo.LastName,
                    SellerEmail = t.Offer.Seller.Email,
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
                    OfferDescription = t.Offer.Description,
                    Status = t.Offer.Status,
                    CreatedOn = t.Offer.CreatedOn,
                    EndedOn = t.EndedOn,
                })
                .ToListAsync();

            return Ok(transaction);
        }

    }
}
