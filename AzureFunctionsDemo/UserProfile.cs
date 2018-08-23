using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunctionsDemo
{
    public class UserProfile
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string LastLogin { get; set; }
        public bool IsLocked { get; set; }
        public string Status { get; set; }
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
    }
}
