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
                options.SubscriberName = "<SubscriberName>";
                options.TopicName = "<TopicName>";
            });

            Configure<AbpAzureServiceBusOptions>(options =>
            {
                options.Connections.Default.ConnectionString = "<ConnectionString>";
            });
        }
    }
}
