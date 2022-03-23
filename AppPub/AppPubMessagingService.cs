using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace AppPub
{
    public class AppPubMessagingService : ITransientDependency
    {
        private readonly IDistributedEventBus _distributedEventBus;

        public AppPubMessagingService(IDistributedEventBus distributedEventBus)
        {
            _distributedEventBus = distributedEventBus;
        }

        public async Task RunAsync()
        {
            Console.WriteLine("*** Started the APPPUB ***");
            Console.WriteLine("Write a message and press ENTER");
            Console.WriteLine("Press ENTER (without writing a message) to stop the application.");

            string message;
            do
            {
                Console.WriteLine();

                message = Console.ReadLine();

                if (!message.IsNullOrEmpty())
                {
                    await _distributedEventBus.PublishAsync(new Message(){Text = message});
                    Console.WriteLine("*** Message sent ***");
                }
                else
                {
                    Console.WriteLine("Bye");
                }

            } while (!message.IsNullOrEmpty());
        }
    }
}