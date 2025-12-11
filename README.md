# EntiryFrameworkWebAPI
A clean and scalable .NET 10 Web API built with Entity Framework Core following a Clean Architecture design.
It implements a Data Access Layer with the Repository Pattern, a Business Logic Layer, API Key authentication, middleware for request logging, custom exception handling, and fully asynchronous CRUD endpoints.
Integrated Swagger UI allows easy testing and documentation.

📂 Project Structure
Web API Layer
Controllers/        → API controllers and endpoints
Interfaces/         → API contracts and abstractions
Middleware/         → Request logging, exception handling, custom middleware
Security/           → API Key authentication logic
Services/           → Application-level services

Business Logic Layer (BLL)
BusinessLogicLayer/
├── Helpers/        → Utility helpers for business rules
├── Interfaces/     → Business logic abstractions
└── Services/       → Business services implementing core logic

Data Access Layer (DAL)
DataAccessLayer/
├── Data/           → DbContext and EF configuration
├── IRepository/    → Repository interfaces
├── Repository/     → Repository implementations
└── Models/         → Entity models (Code-First)

🚀 Key Features

✔️ Clean architecture

✔️ Entity Framework Core (Code-First)

✔️ Data Access Layer with Repository Pattern

✔️ Business Logic Layer for service abstraction

✔️ Asynchronous endpoints

✔️ Validation and error handling

✔️ API Key authentication

✔️ Swagger UI documentation

✔️ Custom exception handling

✔️ API request middleware with request logging

🧰 Tech Stack

.NET 10

Entity Framework Core

Swagger / Swashbuckle

Serilog & NLog

⚙️ Setup Instructions
1️⃣ Clone the repository
git clone https://github.com/your-username/EntityFrameworkWebAPI.git
cd EntityFrameworkWebAPI

2️⃣ Configure the database

Update the connection string in appsettings.json

4️⃣ Run the API
dotnet run


Swagger UI will run automatically on startup

📡 API Endpoints
Method	Endpoint	Description
GET	  /api/GetAllProducts	Retrieve all products
GET	  /api/GetProductById/{id}	Retrieve a product by ID
POST	/api/AddProduct	Add a new product
POST	/api/DeleteProduct/{id}	Delete a product by ID
POST	/api/UpdateProduct	Update an existing product

🔐 API Key Authentication

All endpoints require a valid API Key in the request headers:

X-Api-Key

