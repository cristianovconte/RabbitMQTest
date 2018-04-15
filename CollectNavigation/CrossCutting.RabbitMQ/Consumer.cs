using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RepositoriesServices.CollectNavigation;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Text;

namespace CrossCutting.RabbitMQ
{

    public sealed class Consumer
    {
        private static volatile Consumer instance;

        private static object syncRoot = new Object();

        private ConnectionFactory _instaceFactoryRabbitMQ;

        public static Consumer Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Consumer();
                    }
                }

                return instance;
            }
        }

        private Consumer() => _instaceFactoryRabbitMQ = new ConnectionFactory() { HostName = ConfigurationManager.AppSettings["RabbitMQHostName"] };

        /// <summary>
        /// Método para enviar a navegação do site para uma fila especifica no RabbitMQ
        /// </summary>
        /// <param name="page">Nome da página da navegação</param>
        public void Receive(ICollectNavigationRepositoriesService collectNavigationRepositoriesService)
        {
            using (var connection = _instaceFactoryRabbitMQ.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: ConfigurationManager.AppSettings["RabbitMQQueueName"], type: "fanout");

                var queueName = channel.QueueDeclare().QueueName;
                channel.QueueBind(queue: queueName,
                                  exchange: ConfigurationManager.AppSettings["RabbitMQQueueName"],
                                  routingKey: "");

                Console.WriteLine(" [*] Waiting for logs.");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] {0}", message);

                    collectNavigationRepositoriesService.Save(new Domain.ConsumerNavigation.Navigation() { Name = message, Description = message });
                };
                channel.BasicConsume(queue: queueName,
                                     autoAck: true,
                                     consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}
