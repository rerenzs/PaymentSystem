# PaymentSystem
PaymentSystem
How to build and run the project:

- Download code from repo.
- Set PaymentSystem.API as Startup Project
- Change connection strings with your sql server name
- Open package manager console, select "Payment.Persistence" as Default Project then run the following commands
	"Update-Database"

- Run the project in IIS Express.
- For better viewing of JSON returns use Postman.

API
================================================
//get all accounts
GET https://localhost:44341/api/accounts

//Generate JWT Token
================================================
POST https://localhost:44341/api/token
payload body: 
{
    "username" : "peter@mail.com",
    "userEmail" : "peter@mail.com",
    "password" : ""
}


API with JWT Authentication
================================================
Add Header for authorization.

Key: Authorization
Value: Bearer {Generated Token}
	
//get all payments from the authenticated account
GET https://localhost:44341/api/payments

//get payment by paymentid from the authenticated account
GET https://localhost:44341/api//payments/{paymentid}

Solution Structure
=======================================================
- PaymentSystem.API - presentation layer for http api
- PaymentSystem.Domain - Project for entities and enums.
- PaymentSystem.Persistence - Project that contains the Db Context and repository implementation.
- PaymentSystem.Services - Project that contains all the services implementation that will be used in the presentation layer.
- PaymentSystem.UnitTest - Project for unit testing
