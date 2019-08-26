using MassTransit;
using MassTransitConsole;
using System;

namespace MassTransitReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
            {
                var host = sbc.Host(new Uri("rabbitmq://localhost"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                sbc.ReceiveEndpoint(host, "test_queue", ep =>
                {
                    ep.Handler<ValueEntered>(context =>
                    {
                        return Console.Out.WriteLineAsync($"Received: {context.Message.Value}");
                    });
                });
            });

            bus.Start(); // This is important!

            bus.Publish<ValueEntered>( new { Value = "Olá mundo!!"});

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            bus.Stop();
        }
    }
}
