# HTYF Event Booking System — Technical Documentation

## 1. Project Overview

## 2. Architecture & Design Decisions

## 3. Application Layers Breakdown

## 4. Database Design

## 5. Authentication & Authorization

## 6. Event Booking Workflow

## 7. Memberbase API Integration

## 8. Error Handling & Logging

## 9. Secrets Management & Security

## 10. AI Assistance Disclosure



## 1. Project Overview

HTYF Event Booking System is a web-based ASP.NET Core MVC application designed to manage events, allow authenticated users to book events, and synchronize booking data with the Memberbase CRM platform.

The system supports:
- Event listing and filtering
- Secure user authentication
- Event booking by logged-in users
- CRM synchronization via Memberbase API
- Clean Architecture separation of concerns


- 
## 2. Architecture & Design Decisions

The application follows Clean Architecture principles to ensure maintainability, scalability, and testability.

Key decisions:
- MVC pattern for UI rendering
- Clean separation between Web, Application, Domain, and Infrastructure layers
- Dependency Injection for service decoupling
- EF Core for data persistence
- HttpClientFactory for external API communication



## 3. Application Layers Breakdown

### HTYF.Domain
Contains core business entities such as Event and EventBooking.
This layer has no dependencies on other layers.

### HTYF.Application
Contains business logic, interfaces, DTOs, and ViewModels.
Defines contracts such as IEventService, IBookingService, and IMemberbaseService.

### HTYF.Infrastructure
Handles external concerns such as:
- Entity Framework Core DbContext
- Database migrations
- Memberbase API integration

### HTYF.Web
The presentation layer.
Contains MVC Controllers, Views, authentication UI, and routing logic.



## 4. Database Design

The system uses SQL Server with Entity Framework Core.

### Tables
- Events
- EventBookings
- ASP.NET Identity tables

### Relationships
- One Event can have many EventBookings
- Each EventBooking references one Event via EventId

Migrations are managed using EF Core.



## 5. Authentication & Authorization

Authentication is implemented using ASP.NET Core Identity with Individual Accounts.

Authorization rules:
- Event listing and details are public
- Event booking requires authentication
- Anonymous users are redirected to login when accessing booking routes

The [Authorize] attribute is applied to booking-related controllers.



## 6. Event Booking Workflow

1. User browses available events
2. User views event details
3. Authenticated users can click "Book Now"
4. Booking form is validated server-side
5. Booking is saved to the database
6. User is redirected back to the events page with feedback



## 7. Memberbase API Integration

The application integrates with Memberbase CRM using HttpClient.

Integration steps:
- Contact is created or updated upon successful booking
- Event name is used as a tag in Memberbase
- API requests are logged
- Failures do not block booking persistence

Memberbase communication is encapsulated in the IMemberbaseService abstraction.



## 8. Error Handling & Logging

The application uses built-in ASP.NET Core logging.

Handled scenarios:
- Database errors during booking
- External API failures from Memberbase
- HTTP request failures

Memberbase errors are logged without interrupting the booking flow.



## 9. Secrets Management & Security

Sensitive information such as API keys is not hardcoded.

Measures taken:
- Memberbase API key stored using .NET User Secrets during development
- Secrets excluded from source control via .gitignore
- Configuration values accessed via IConfiguration

Previously committed secrets were rotated to ensure security.



## 10. AI Assistance Disclosure

AI tools (GitHub Copilot) were used as a development aid to:
- Clarify Clean Architecture concepts
- Validate ASP.NET Core MVC best practices
- Assist in debugging and understanding framework behavior
- Improve documentation clarity and structure

All architectural decisions, code implementation, debugging, and final integrations were performed and verified by the developer.