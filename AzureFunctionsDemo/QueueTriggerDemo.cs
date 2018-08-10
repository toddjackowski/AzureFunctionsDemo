using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace AzureFunctionsDemo
{
    public static class QueueTriggerDemo
    {
        [FunctionName("Function2")]
        public static void Run([QueueTrigger("myqueue-items", Connection = "")]string myQueueItem, TraceWriter log)
        {
            log.Info($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
