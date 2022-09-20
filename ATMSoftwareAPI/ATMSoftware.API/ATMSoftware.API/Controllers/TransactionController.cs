using ATMSoftware.API.Data;
using ATMSoftware.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace ATMSoftware.API.Controllers
{
    [ApiController]
    [Route("api/viewingTransactions")]
    public class TransactionController : Controller
    {
        private readonly BankingSystemDbContext _bankingSystemDbContext;
        public TransactionController(BankingSystemDbContext bankingSystemDbContext)
        {
            _bankingSystemDbContext = bankingSystemDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> StoreTransaction(Transaction transactionRequest)
        {
            var customerInfo =
               await _bankingSystemDbContext.CustomersData.FirstOrDefaultAsync(x => x.AccountNumber == transactionRequest.AccountNumber);

            if (customerInfo == null)
                return NotFound();
            if (customerInfo.CardPin != transactionRequest.Pin)
                return Unauthorized();

            if (customerInfo.TotalBalance < transactionRequest.AmountTransfer)
                return NotFound();
            else
                customerInfo.TotalBalance -= transactionRequest.AmountTransfer;


            var updateInfo =
                await _bankingSystemDbContext.CustomersData.FirstOrDefaultAsync(x => x.AccountNumber == transactionRequest.RecipientAccountNumber);

            if (updateInfo == null)
                return NotFound();

            updateInfo.TotalBalance += transactionRequest.AmountTransfer;


            Random rnd = new Random();
            transactionRequest.TransactionId = rnd.Next(10000, 100000);
            await _bankingSystemDbContext.TransactionRecord.AddAsync(transactionRequest);
            await _bankingSystemDbContext.SaveChangesAsync();

            return Ok(transactionRequest);
        }
    }
}