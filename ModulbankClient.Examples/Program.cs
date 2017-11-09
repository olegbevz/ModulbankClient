using System;

namespace ModulbankClient.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // var token = "Put your access token here...";
                // var modulebankClient = new ModulbankClient(token);

                var modulebankClient = ModulbankClient.CreateSandboxClient();

                var companies = modulebankClient.GetAccountInfo();

                foreach (var company in companies)
                {
                    Console.WriteLine(company.CompanyName);
                    Console.WriteLine();

                    foreach (var bankAccount in company.BankAccounts)
                    {
                        ProcessBankAccount(modulebankClient, bankAccount);

                        Console.WriteLine();
                    }

                    Console.WriteLine();
                }

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ProcessBankAccount(ModulbankClient modulebankClient, BankAccount bankAccount)
        {
            Console.WriteLine(bankAccount.AccountName);

            var balance = modulebankClient.GetBalance(bankAccount.Id);
            Console.WriteLine($"{balance} {bankAccount.Currency}");

            var condition = new OperationCondition
            {
                Category = OperationCategory.Credit,
                Records = 50,
                Skip = 10,
                Till = DateTime.Now,
                From = DateTime.Now.Subtract(TimeSpan.FromDays(10))
            };

            var operations = modulebankClient.GetOperationHistory(bankAccount.Id, condition);

            foreach (var operation in operations)
            {
                Console.WriteLine($"{operation.Executed} {operation.Amount} {operation.Currency} {operation.PaymentPurpose}");
            }
        }
    }
}
