using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System;
using System.Text;

namespace Bank.Api
{
    public class BaseControllerWithRabbit : ControllerBase
    {
        protected static string SendMessage(string message, string queue)
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
