using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MSAL.Test
{
    public static class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureServices(services =>
                {
                })
                .Build();

            host.Run();
        }
    }

    public class Function1
    {
        [Function("MSALTest")]
        public void Run([TimerTrigger("0 */1 * * * *")]TimerInfo myTimer, FunctionContext context)
        {
            var log= context.GetLogger(nameof(Function1));

            var client = new ClientLib.Client();

            var str = client.TestAsync(log).GetAwaiter().GetResult();
            log.LogInformation($"C# MSAL Test Timer trigger function executed at: {DateTime.Now}: {str}");
        }
    }
}
