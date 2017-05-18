using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace TestPlatform
{
   public class RabbitMqTestExchange
    {
        public static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            w.WriteLine("  :");
            w.WriteLine("  :{0}", logMessage);
            w.WriteLine("-------------------------------");
        }

        public void SendmessageToRabbitMq()
       {

            //Send Code
            /*
            var factory = new ConnectionFactory() { HostName = "10.21.50.60" };
            //var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "deneme-logs", type: "fanout");

                string message = "ilk mesaj";
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: "deneme-logs",
                                                 routingKey: "",
                                                 basicProperties: null,
                                                 body: body);
                Console.WriteLine(" [x] Gönderildi {0}", message);
            }
           */

            //Receive Kod
            
            var factory = new ConnectionFactory() { HostName = "10.21.50.60" };
            using ( var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "fanatik-logs", type: "fanout");

                var queueName = channel.QueueDeclare().QueueName;
                channel.QueueBind(queue: queueName,
                                  exchange: "fanatik-logs",
                                  routingKey: "#");

                Console.WriteLine(" [*] Waiting for logs.");

                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] {0}", message);

                    using (StreamWriter w = File.AppendText("log.txt"))
                    {
                        Log(message, w);
                       
                    }

                    
                };

                channel.BasicConsume(queue: queueName,
                                     noAck: true,
                                     consumer: consumer);

              
                
            }
            
            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();


        }

    }
}
