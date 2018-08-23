using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace AzureFunctionsDemo
{
    public static class ProcessUserQueueTriggerDemo
    {
        [FunctionName("ProcessUser")]
        public static User Run([QueueTrigger("new-user-requests")]UserProfile user, 
            //[Blob("failed-users/{rand-guid}")] IAsyncCollector<UserProfile> failedUser, 
            [Table("userlogin")] User newUser,
            TraceWriter log)
        {
            log.Info($"C# Queue trigger function processed: {user.EmailAddress}");

            //try
            //{
            // Add the new user to the table
            newUser = new User()
            {
                RowKey = user.UserName,
                PartitionKey = "User",
                Status = "Success",
                FirstName = user.FirstName
            };

            return newUser;
                
                //outputTable..Add(user);

                //failedUser = null;
            //}
            //catch(Exception ex)
            //{
            //    user.Status = $"Error adding user {user.EmailAddress}. Error: {ex.Message}.";
            //    //failedUser = null;
            //    outputTable = null;
            //}
        }
    }

    public class User
    {
        public string FirstName { get; set; }
        public string Status { get; set; }
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
    }

}
