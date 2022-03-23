using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ClientLib
{
    public class Client
    {
        public async Task<string> TestAsync(ILogger log)
        {
            IConfidentialClientApplication app = null;

            const string ClientId = "00000000-0000-0000-0000-000000000000";
            const string resourceId = "https://msaltest.com";
            const string authority = "https://login.microsoftonline.com/00000000-0000-0000-0000-000000000000";

            log.LogInformation("C# HTTP trigger function processed a request.");
            if (app == null)
            {
                app = ConfidentialClientApplicationBuilder.Create(ClientId)
                .WithClientSecret("SECRET")
                .WithAuthority(authority)
                .Build();
            }

            var authResult = await app.AcquireTokenForClient(new[] { $"{resourceId}/.default" })
                                .ExecuteAsync()
                                .ConfigureAwait(false);

            string responseMessage = $"Access Token :  {authResult.AccessToken}. OS Description : { RuntimeInformation.OSDescription } This HTTP triggered function executed successfully.";

            return responseMessage;
        }
    }
}
