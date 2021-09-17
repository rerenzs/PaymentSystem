# PaymentSystem
PaymentSystem
How to build and run the project:

- Download code from repo.
- Set PaymentSystem.API as Startup Project
- Change connection strings with your sql server name
- Open package manager console, select "Payment.Persistence" as Default Project then run the following commands
	"Add-Migration <any migration name>"
	"Update-Database"

- Run the project in IIS Express.
- For better viewing of JSON returns use Postman.

API
================================================
//get all accounts
GET https://localhost:44341/api/accounts

//get account by id
GET https://localhost:44341/api/accounts/{accountid}

//get all payments from an account
GET https://localhost:44341/api/accounts/{accountid}/payments

//get payment by paymentid from an account
GET https://localhost:44341/api/accounts/{accountid}/payments/{paymentid}

Sample payloads for adding accounts and payments
================================================

POST
https://localhost:44341/api/accounts
{  
    "AccountNumber": 4564645,
    "Name": "Clark Kent",
    "Balance": 7500.00
}

POST
https://localhost:44341/api/accounts/{accountid}/payments
{
        "Date": "2021-09-10T12:44:14.1337954",
        "Amount": 222222.00,
        "Reason": "some reason",
        "Status": "Pending"
}

Solution Structure
=======================================================
- PaymentSystem.API - presentation layer for http api
- PaymentSystem.Domain - Project for entities, enums and interfaces.
- PaymentSystem.Persistence - Project that contains the Db Context and repository implementation.
- PaymentSystem.Services - Project that contains all the services implementation that will be used in the presentation layer.
- PaymentSystem.UnitTest - Project for unit testing
