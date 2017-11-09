using Newtonsoft.Json;
using System;

namespace ModulbankClient
{
    public class Operation
    {
        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("amountWithCommission")]
        public double AmountWithCommission { get; set; }

        [JsonProperty("bankAccountNumber")]
        public string BankAccountNumber { get; set; }

        [JsonProperty("category")]
        public OperationCategory Category { get; set; }

        [JsonProperty("companyId")]
        public Guid CompanyId { get; set; }

        [JsonProperty("contragentBankAccountNumber")]
        public string ContragentBankAccountNumber { get; set; }

        [JsonProperty("contragentBankBic")]
        public string ContragentBankBic { get; set; }

        [JsonProperty("contragentBankName")]
        public string ContragentBankName { get; set; }

        [JsonProperty("contragentInn")]
        public string ContragentInn { get; set; }

        [JsonProperty("contragentKpp")]
        public string ContragentKpp { get; set; }

        [JsonProperty("contragentName")]
        public string ContragentName { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("executed")]
        public DateTime Executed { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("kbk")]
        public string Kbk { get; set; }

        [JsonProperty("oktmo")]
        public string Oktmo { get; set; }

        [JsonProperty("payerStatus")]
        public string PayerStatus { get; set; }

        [JsonProperty("paymentBasis")]
        public string PaymentBasis { get; set; }

        [JsonProperty("paymentPurpose")]
        public string PaymentPurpose { get; set; }

        [JsonProperty("status")]
        public OperationStatus Status { get; set; }

        [JsonProperty("taxCode")]
        public string TaxCode { get; set; }

        [JsonProperty("taxDocDate")]
        public string TaxDocDate { get; set; }

        [JsonProperty("taxDocNum")]
        public string TaxDocNum { get; set; }

        [JsonProperty("uin")]
        public string Uin { get; set; }
    }
}
