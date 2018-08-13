using IoTHubTrigger = Microsoft.Azure.WebJobs.ServiceBus.EventHubTriggerAttribute;

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.ServiceBus.Messaging;
using System.Text;
using System.Net.Http;

namespace AzureFunctionsDemo
{
    public static class IotHubTriggerDemo
    {
        private static HttpClient client = new HttpClient();

        [FunctionName("IotHubTriggerDemo")]
        public static void Run([IoTHubTrigger("messages/events", Connection = "")]EventData message, TraceWriter log)
        {
            log.Info($"C# IoT Hub trigger function processed a message: {Encoding.UTF8.GetString(message.GetBytes())}");
        }
    }
}