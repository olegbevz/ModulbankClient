using Newtonsoft.Json;
using System;

namespace ModulbankClient
{
    public class Company
    {
        [JsonProperty("companyId")]
        public Guid CompanyId { get; set; }

        [JsonProperty("companyName")]
        public string CompanyName { get; set; }

        [JsonProperty("bankAccounts")]
        public BankAccount[] BankAccounts { get; set; }
    }
}
