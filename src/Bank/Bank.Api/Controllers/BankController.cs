using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bank.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : BaseControllerWithRabbit
    {        
        [HttpPost("account")]
        public async Task<ActionResult<string>> CheckAccountBalance(string message)
        {            
            var response = SendMessage(message, "account");

            return Ok(response);
        }        

        [HttpPost("withdrawal")]
        public async Task<ActionResult<string>> WithDrawFromAccount(string message)
        {
            var response = SendMessage(message, "withdrawal");

            return Ok(response);
        }        
    }
}
