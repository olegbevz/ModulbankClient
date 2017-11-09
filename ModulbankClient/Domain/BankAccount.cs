using Newtonsoft.Json;
using System;

namespace ModulbankClient
{
    public class BankAccount
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("accountName")]
        public string AccountName { get; set; }

        [JsonProperty("balance")]
        public double Balance { get; set; }

        [JsonProperty("bankBic")]
        public string BankBic { get; set; }

        [JsonProperty("bankCorrespondentAccount")]
        public string BankCorrespondentAccount { get; set; }

        [JsonProperty("bankInn")]
        public string BankInn { get; set; }

        [JsonProperty("bankKpp")]
        public string BankKpp { get; set; }

        [JsonProperty("bankName")]
        public string BankName { get; set; }

        [JsonProperty("beginDate")]
        public DateTime BeginDate { get; set; }

        [JsonProperty("category")]
        public BankAccountCategory Category { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("status")]
        public BankAccountStatus Status { get; set; }
    }
}
