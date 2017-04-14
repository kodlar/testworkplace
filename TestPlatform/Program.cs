
namespace TestPlatform
{
    class Program
    {
        static void Main(string[] args)
        {
            RabbitMqTestExchange logic = new RabbitMqTestExchange();
            logic.SendmessageToRabbitMq();

        }
    }
}
