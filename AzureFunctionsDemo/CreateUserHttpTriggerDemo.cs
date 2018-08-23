using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace AzureFunctionsDemo
{
    public static class CreateUserHttpTriggerDemo
    {
        [FunctionName("CreateUser")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]HttpRequestMessage req, 
            [Queue("new-user-requests")] IAsyncCollector<UserProfile> messageQueue, 
            TraceWriter log)
        {
            log.Info("Process new user requests.");

            UserProfile user = null;

            try
            {
                // Parse the JSON from the request and create a new user profile record for processing.
                user = await req.Content.ReadAsAsync<UserProfile>();
            }
            catch(Exception ex)
            {
                log.Error("Error parsing user profile", ex);

                return req.CreateErrorResponse(HttpStatusCode.BadRequest, "New user information is invalid and cannot be parsed.", ex);
            }

            // TODO: Add a check to see if the username already exists by checking the user login table.
            //HttpStatusCode.Conflict

            await messageQueue.AddAsync(user);

            return req.CreateResponse(HttpStatusCode.Accepted, $"New user request submitted for {user.FirstName} {user.LastName}.");
        }
    }
}
