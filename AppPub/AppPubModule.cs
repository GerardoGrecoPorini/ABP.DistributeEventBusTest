using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Autofac;
using Volo.Abp.AzureServiceBus;
using Volo.Abp.EventBus.Azure;
using Volo.Abp.Modularity;

namespace AppPub
{
    [DependsOn(
        typeof(AbpEventBusAzureModule),
        typeof(AbpAutofacModule)
    )]
    public class App1Module : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAzureEventBusOptions>(options =>
            {
                options.ConnectionName = "Default";
                options.SubscriberName = "ABP.AzureEventBusPub";
                options.TopicName = "ABP.AzureEventBus";
            });

            Configure<AbpAzureServiceBusOptions>(options =>
            {
                options.Connections.Default.ConnectionString = "Endpoint=sb://sb-epson-poc-env01-sb01.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=10XDWQ6xhMKKfULK5JHZPu3bSZZ/f4qBQ74R6uGQKD4=";
            });
        }
    }
}
