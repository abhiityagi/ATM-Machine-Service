using ATMSoftware.API.Data;
using ATMSoftware.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ATMSoftware.API.Controllers
{
    [ApiController]
    [Route("api/getBalance")]
    public class CustomersDataController : Controller
    {
        private readonly BankingSystemDbContext _bankingSystemDbContext;
        public CustomersDataController(BankingSystemDbContext bankingSystemDbContext)
        {
            _bankingSystemDbContext = bankingSystemDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTransactions()
        {
            var transactions = await _bankingSystemDbContext.TransactionRecord.ToListAsync();

            return Ok(transactions);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerData customerRequest)
        {
            customerRequest.Id = Guid.NewGuid();
            await _bankingSystemDbContext.CustomersData.AddAsync(customerRequest);
            await _bankingSystemDbContext.SaveChangesAsync();

            return Ok(customerRequest);
        }

        [HttpGet]
        [Route("{id:long}")]

        public async Task<IActionResult> GetBalance([FromRoute] long id, int pin)
        {
            var customerInfo =
                await _bankingSystemDbContext.CustomersData.FirstOrDefaultAsync(x => x.AccountNumber == id);

            if (customerInfo == null)
            {
                return NotFound();
            }

            if (customerInfo.CardPin != pin)
            {
                return Unauthorized();
            }

            float balance = customerInfo.TotalBalance;
            string name = customerInfo.FullName;

            return Ok(new {name, balance});
        }
    }
}
