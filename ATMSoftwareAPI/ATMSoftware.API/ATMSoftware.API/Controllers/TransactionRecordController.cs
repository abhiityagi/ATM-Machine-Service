using ATMSoftware.API.Data;
using ATMSoftware.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ATMSoftware.API.Controllers
{
    [ApiController]
    [Route("api/viewTransactions")]
    public class TransactionRecordController : Controller
    {
        private readonly BankingSystemDbContext _bankingSystemDbContext;
        public TransactionRecordController(BankingSystemDbContext bankingSystemDbContext)
        {
            _bankingSystemDbContext = bankingSystemDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> StoreTransaction([FromBody] Transactions transactionRequest)
        {
            Random rnd = new Random();
            transactionRequest.TransactionId = rnd.Next(1,7);
            await _bankingSystemDbContext.TransactionsData.AddAsync(transactionRequest);
            await _bankingSystemDbContext.SaveChangesAsync();

            return Ok(transactionRequest);
        }
    }
}
