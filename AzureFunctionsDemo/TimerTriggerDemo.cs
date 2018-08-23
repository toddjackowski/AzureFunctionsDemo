using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;

namespace AzureFunctionsDemo
{
    public static class TimerTriggerDemo
    {
        [Disable]
        [FunctionName("TimerTriggerDemo")]
        public static void Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer, TraceWriter log)
        {
            // Get the list of users from table storage

            // loop through the results and check the last login time

            // If greater than 30 days, send an email and lock the user.

            var acc = new CloudStorageAccount(new StorageCredentials("devstoreaccount1", "Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw=="), false);
           // var acc = CloudStorageAccount.Parse(ConfigurationManager.GetSetting("StorageConnectionString"));
            var tableClient = acc.CreateCloudTableClient();
            var table = tableClient.GetTableReference("UserLogin");
            var entities = table.ExecuteQuery(new TableQuery<UserLogin>()).ToList();


            //CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=your_account;AccountKey=your_account_key");

            //CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            //CloudTable userLoginTable = tableClient.GetTableReference("UserLogin");


            //TableOperation retrieveOperation = TableOperation.Retrieve<UserLogin>("", "");

            //TableResult result = await table.ExecuteAsync(retrieveOperation);

            //CustomerEntity customer = new CustomerEntity("Harp", "Walter");
            //customer.Email = "Walter@contoso.com";
            //customer.PhoneNumber = "425-555-0101";

            //TableOperation insertOperation = TableOperation.Insert(customer);

            //await table.ExecuteAsync(insertOperation);

            //TableOperation retrieveOperation = TableOperation.Retrieve<customerentity>("Harp", "Walter");

            

            log.Info($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }

    public class UserLogin : ITableEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime LastLogin { get; set; }
        public bool IsLocked { get; set; }
        public string PartitionKey { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string RowKey { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTimeOffset Timestamp { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ETag { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void ReadEntity(IDictionary<string, EntityProperty> properties, OperationContext operationContext)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, EntityProperty> WriteEntity(OperationContext operationContext)
        {
            throw new NotImplementedException();
        }
    }
}
