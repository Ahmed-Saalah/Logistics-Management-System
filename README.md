# Logex

**Logex** is a **shipping API built with ASP.NET Core Web API**. It allows businesses to create and manage shipments, track orders, process payments, and integrate with external services like Stripe. The system follows a **scalable, layered architecture** for efficient backend operations.

---

## Table of Contents

- [Features](#features)  
- [Technology Stack](#technology-stack)  
- [Getting Started](#getting-started)  
- [API Endpoints](#api-endpoints)

---

## Features

- **Shipment Creation**: Create shipments with sender/receiver information, weight, quantity, item details, and shipment methods.  
- **Payment Processing**: Securely handle payments through **Stripe**, supporting credit and debit cards.  
- **Multiple Shipment Methods**: Supports predefined methods (e.g., `Standard`) and can be extended to other shipping options.  
- **Customer Authentication**: **JWT-based authentication** via ASP.NET Identity ensures only authorized users can create shipments or make payments.  
- **Error Handling**: Provides meaningful responses for invalid shipment data, payment failures, or unauthorized access.  
- **Repository Pattern**: Uses a **layered architecture** separating data access, business logic, and presentation layers for maintainability and testability.

---

## Technology Stack

- **Backend**: **ASP.NET Core (C#)**
- **Database**: **SQL Server**
- **Payment Gateway**: **Stripe API**
- **Authentication**: **JWT via ASP.NET Identity**
- **ORM**: **Entity Framework Core** 
- **Validation**: - **FluentValidation**
---

## Getting Started

1. Clone the repository:  
   ```bash
   git clone https://github.com/Ahmed-Saalah/Logex.git
2. Open the solution in Visual Studio.
3. Update appsettings.json with your database connection string and Stripe API keys.
4. Run database migrations:
   ```bash
   dotnet ef database update
5.Run the project:
   ```bash
   dotnet run
   ```
6. Access the API via Swagger UI.

## API Endpoints

### **Authentication**  
- `POST /api/Auth/register` → Register a new user.  
- `POST /api/Auth/login` → Authenticate and get a JWT token.  
- `POST /api/Auth/refreshToken/{refreshToken}` → Refresh JWT token.

---

### **Payment**  
- `POST /api/Payment/checkout` → Process a payment for a shipment

---

### **Shipment**  
- `POST /api/Shipment` → Create a new shipment
- `GET /api/Shipment/{id}` → Retrieve shipment details by ID
- `PUT /api/Shipment/{id}` → Update shipment details by ID
- `DELETE /api/Shipment/{id}` → Delete a shipment by ID
- `GET /api/Shipment/{id}` → Retrieve shipment details by ID
- `GET /api/Shipment/tracking/{trackingNumber}` → Track a shipment by tracking number
- `POST /api/Shipment/rateCalculator` → Calculate shipping rates
