using ATMSoftware.API.Data;
using Microsoft.AspNetCore.Mvc;
using ATMSoftware.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ATMSoftware.API.Controllers
{
    [ApiController]
    [Route("api/setDeposit")]
    public class DepositAmountController : Controller
    {
        private readonly BankingSystemDbContext _bankingSystemDbContext;

        public DepositAmountController(BankingSystemDbContext bankingSystemDbContext)
        {
            _bankingSystemDbContext = bankingSystemDbContext;
        }

        [HttpPut]
        [Route("{id:long}")]
        public async Task<IActionResult> SetDeposit([FromRoute] long id, int pin, float newBal)
        {
            var updateInfo =
                await _bankingSystemDbContext.CustomersData.FirstOrDefaultAsync(x => x.AccountNumber == id);

            if (updateInfo == null)
            {
                return NotFound();
            }

            if (updateInfo.CardPin != pin)
            {
                return Unauthorized();
            }

            updateInfo.TotalBalance += newBal;
            float balance = updateInfo.TotalBalance;
            string name = updateInfo.FullName;

            await _bankingSystemDbContext.SaveChangesAsync();
            return Ok(new { name, balance });
        }
    }
}