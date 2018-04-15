using RabbitMQ.Client;
using System;
using System.Text;
using System.Configuration;

namespace CrossCutting.RabbitMQ
{
    public sealed class Producer
    {
        private static volatile Producer instance;

        private static object syncRoot = new Object();

        private ConnectionFactory _instaceFactoryRabbitMQ;

        public static Producer Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Producer();
                    }
                }

                return instance;
            }
        }

        private Producer() => _instaceFactoryRabbitMQ = new ConnectionFactory() { HostName = ConfigurationManager.AppSettings["RabbitMQHostName"] };

        /// <summary>
        /// Método para enviar a navegação do site para uma fila especifica no RabbitMQ
        /// </summary>
        /// <param name="page">Nome da página da navegação</param>
        public void Send(string message)
        {
            using (var connection = _instaceFactoryRabbitMQ.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: ConfigurationManager.AppSettings["RabbitMQQueueName"], type: "fanout");

               var messageDebug = string.Format("(Navegacao Site) - {0}", message);

                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: ConfigurationManager.AppSettings["RabbitMQQueueName"],
                                     routingKey: "",
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}
