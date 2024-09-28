using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace MultiShop.RabbitMQMessage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateMessage()
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            var connection = connectionFactory.CreateConnection();

            var channel = connection.CreateModel();

            channel.QueueDeclare("Kuyruk2", false, false, false, arguments: null);

            var messageContent = "Merhaba bugün hava çok soğuk.";

            var byteMessageContent = Encoding.UTF8.GetBytes(messageContent);

            channel.BasicPublish(exchange: "", routingKey: "Kuyruk2", basicProperties: null, body: byteMessageContent);

            return Ok("Mesajınız Kuyruğa Alınmıştır.");
        }

        [HttpGet]
        public IActionResult GetMessages()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            List<string> messages = new List<string>();

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                while (true)
                {
                    var result = channel.BasicGet(queue: "Kuyruk2", autoAck: false);

                    if (result == null)
                    {
                        break;
                    }

                    var byteMessage = result.Body.ToArray();
                    var message = Encoding.UTF8.GetString(byteMessage);
                    messages.Add(message);
                }
            }

            if (messages.Count == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(messages);
            }
        }
    }
}
