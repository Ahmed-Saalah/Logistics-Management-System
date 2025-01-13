# Logistics Management System

This Logistics Management System is an **ASP.NET Core Web API** designed to efficiently manage the creation of shipments, track order statuses, handle customer payments, and integrate with external services such as Stripe for payment processing. The system provides a structured and scalable approach to handling logistics and transaction management for businesses.

## Table of Contents

- [Features](#features)
- [Technology Stack](#technology-stack)


## Features

- **Create Shipment**: Enables users to create shipments by providing essential details such as sender/receiver information, quantity, weight, shipment method, and item details. 
- **Payment Integration**: Seamlessly integrates with Stripe to process payments for shipments. This allows businesses to handle payment transactions securely using credit or debit cards.
- **Shipment Methods**: Supports multiple predefined shipment methods, including a default 'Standard' method, allowing flexibility in how shipments are managed.
- **Customer Authentication**: Utilizes JWT-based authentication (via ASP.NET Identity) to securely verify customer identities, ensuring only authorized users can create shipments or process payments.
- **Error Handling**: Incorporates robust error handling to provide meaningful responses for common issues such as missing shipment data, invalid payment details, unauthorized access, etc.
- **Repository Pattern**: The application follows a layered architecture utilizing the **Repository** pattern, separating concerns between data access logic, business logic, and presentation layers, improving maintainability and testability.

---

## Technology Stack

- **Backend**: **ASP.NET Core** (C#) - A cross-platform, high-performance framework for building modern, cloud-based web APIs.
- **Database**: **SQL Server** (or configure any other database provider) - Handles data storage and retrieval.
- **Payment Gateway**: **Stripe** - Manages secure payment processing.
- **Authentication**: **JWT-based authentication** (via ASP.NET Identity) - Provides secure authentication for API endpoints.
- **ORM**: **Entity Framework Core** - Simplifies database interactions and handles migrations.
- **Stripe API**: Facilitates integration with Stripe for processing payments.
- **Dependency Injection**: Implements dependency injection for service and repository management.
