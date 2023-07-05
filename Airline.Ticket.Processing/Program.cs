// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

Console.WriteLine("Welcome to online ticketing service!");

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
channel.QueueDeclare("bookings", durable: true, exclusive: false);

// set up consumner to receive message silmulteneously
var consumer = new EventingBasicConsumer(channel);

consumer.Received += (sender, args) =>
{
    // getting byte array[]
    var body = args.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);

    Console.WriteLine($"Message has been received for processing {message}");

};

channel.BasicConsume("bookings", true, consumer);

Console.ReadKey();