using RabbitMQ.Client;
using System.Text;


var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "posts",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

var post = new { Title = "Titulo", Content = "Content"};
var body = Encoding.UTF8.GetBytes(post.Title);

channel.BasicPublish(exchange: string.Empty,
                     routingKey: "posts",
                     basicProperties: null,
                     body: body);

Console.WriteLine($"Sent Message: {body}");
Console.ReadLine();