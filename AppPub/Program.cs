using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;

namespace AppPub
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            using (var application = AbpApplicationFactory.Create<App1Module>(options => { options.UseAutofac(); }))
            {
                application.Initialize();

                var messagingService = application
                    .ServiceProvider
                    .GetRequiredService<AppPubMessagingService>();

                await messagingService.RunAsync();

                application.Shutdown();
            }
        }
    }
}
