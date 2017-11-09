# ModulbankClient
Small C# library for Modulbank API

## Requirements
Project tarteted to .NET Framework 4.5

## Instalation
Install nuget package from Package Manager Console

`Install-Package ModulbankClient`

## Getting started

Create an instance of modulbank client with private access token:
```
var token = "Put your access token here...";
var modulebankClient = new ModulbankClient(token);
```
To work with sandbox create sandbox client:
```
var modulebankClient = ModulbankClient.CreateSandboxClient();
```
Request account info with list of companies and bank accounts:
```
var companies = modulebankClient.GetAccountInfo();
```
Request specified bank account balance:
```
var balance = modulebankClient.GetBalance(bankAccount.Id);
```
Request operation history for specified bank account:
```
var condition = new OperationCondition
            {
                Category = OperationCategory.Credit,
                Records = 50,
                Skip = 10,
                Till = DateTime.Now,
                From = DateTime.Now.Subtract(TimeSpan.FromDays(10))
            };

var operations = modulebankClient.GetOperationHistory(bankAccount.Id, condition);
```
## Links
https://api.modulbank.ru
