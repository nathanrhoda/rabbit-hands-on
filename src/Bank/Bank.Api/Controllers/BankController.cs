using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
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

        private static string SendMessage(string message, string queue)
        {
            var response = "Message Not Sent";
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare
                    (
                        queue: queue,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null
                    );

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish
                    (
                        exchange: "",
                        routingKey: queue,
                        basicProperties: null,
                        body: body
                    );
                response = "Message Sent";
                Console.WriteLine($"{response} : {message}");
            }

            return response;
        }
    }
}
