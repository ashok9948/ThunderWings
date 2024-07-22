# Thunder Wings E-commerce API

## Project Overview

Thunder Wings is an e-commerce platform specializing in military jets. This project implements a backend API that allows users to browse, compare, and purchase military aircraft.

## Features

- Browse a catalog of military aircraft
- Filter aircraft based on various properties
- Add and remove items from a shopping basket
- Persist shopping baskets for later retrieval
- Process orders through a checkout system

## Technology Stack

- .NET 6
- C#
- xUnit for testing
- Moq for mocking in tests
- FluentAssertions for more readable test assertions

## Project Structure

The solution follows the Clean Architecture pattern and is organized into the following projects:

1. ThunderWings.Domain
   - Contains entity classes and domain logic

2. ThunderWings.Application
   - Contains interfaces and service classes
   - Implements core business logic

3. ThunderWings.Infrastructure
   - Implements data access and external service integrations
   - Contains repository implementations

4. ThunderWings.API
   - Hosts the API controllers
   - Configures the web application

5. ThunderWings.Tests
   - Contains unit tests for controllers and services

## Key Components

### Entities
- Aircraft
- Basket
- Order

### Services
- AircraftService
- BasketService
- OrderService

### Controllers
- AircraftController
- BasketController
- OrderController

## API Endpoints

1. Aircraft
   - GET /api/Aircraft: Retrieve a list of aircraft with optional filtering

2. Basket
   - GET /api/Basket/{customerId}: Get the basket for a specific customer
   - POST /api/Basket/{customerId}/add: Add an item to the basket
   - POST /api/Basket/{customerId}/remove: Remove an item from the basket

3. Order
   - POST /api/Order/checkout: Process an order checkout

## Testing

The project includes a comprehensive suite of unit tests for controllers. Tests are written using xUnit, with Moq for mocking dependencies and FluentAssertions for more expressive assertions. Note that currently, only one controller has unit tests written. To complete the testing suite, follow the same pattern for the remaining controllers.

To run the tests:
1. Ensure you have the .NET 6 SDK installed
2. Open a terminal in the project root directory
3. Run the command: `dotnet test`

## Setup and Installation

1. Clone the repository
2. Ensure you have .NET 6 SDK installed
3. Open the solution in Visual Studio 2022 or your preferred IDE
4. Restore NuGet packages
5. Build the solution
6. Run the ThunderWings.API project

## Configuration

The application uses in-memory repositories for demonstration purposes. To switch to a different data storage method, you'll need to:

1. Implement new repository classes in the Infrastructure layer
2. Update the dependency injection configuration in Program.cs

