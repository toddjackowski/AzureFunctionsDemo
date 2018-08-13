using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace AzureFunctionsDemo
{
    public static class GitHubWebHookTriggerDemo
    {
        [FunctionName("GitHubWebHookTriggerDemo")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(WebHookType = "github")]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            // Get request body
            dynamic data = await req.Content.ReadAsAsync<object>();

            // Extract github comment from request body
            string gitHubComment = data?.comment?.body;

            return req.CreateResponse(HttpStatusCode.OK, "From Github:" + gitHubComment);
        }
    }
}
