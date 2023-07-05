using System;
using System.Net.Http;
using System.Text;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzureTriggers.Function
{
    public class MessageSender
    {
        [FunctionName("MessageSender")]
        public void Run([TimerTrigger("*/5 * * * *")]TimerInfo myTimer, ILogger log)
        {
            var message = $"C# Timer trigger function executed at: {DateTime.Now}";
            HttpClient client = new();
            HttpRequestMessage requestMessage = new(HttpMethod.Post, "http://localhost:7071/")
            {
                Content = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json")
            };
            client.Send(requestMessage);  

            log.LogInformation("Timer triggered");
        }
    }
}
