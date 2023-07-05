using Airline.Services.Interface;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Airline.Services.Implementation
{
    public class MessageProducer : IMessageProducer
    {
        public void SendingMessages<T>(T message)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "user",
                Password = "password",
                VirtualHost = "/"
            };

            var conn = factory.CreateConnection();

            //create channel here, if its available return it, if not create a new one and return it.
            using var channel = conn.CreateModel();

            //crreat a queue here.
            channel.QueueDeclare("bookings", durable: true, exclusive: true);

            var jsonString = JsonSerializer.Serialize(message);  
            var body = Encoding.UTF8.GetBytes(jsonString);

            //publish message

            channel.BasicPublish("", "bookings", body: body);
        }
    }
}
