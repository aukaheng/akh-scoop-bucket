# Simple Clean Architecture (C#, Services)

This is a **very simple** Clean Architecture example in C#.

- No CQRS
- No MediatR
- Application flow uses plain **services**

## File Structure

```text
examples/clean-architecture-services/
`-- src/
    |-- SimpleStore.Api/
    |   |-- Controllers/
    |   |   `-- ProductsController.cs
    |   |-- Program.cs
    |   `-- SimpleStore.Api.csproj
    |-- SimpleStore.Application/
    |   |-- Abstractions/
    |   |   |-- IProductRepository.cs
    |   |   `-- IProductService.cs
    |   |-- Contracts/
    |   |   `-- ProductDto.cs
    |   |-- Services/
    |   |   `-- ProductService.cs
    |   `-- SimpleStore.Application.csproj
    |-- SimpleStore.Domain/
    |   |-- Entities/
    |   |   `-- Product.cs
    |   `-- SimpleStore.Domain.csproj
    `-- SimpleStore.Infrastructure/
        |-- Persistence/
        |   `-- InMemoryProductRepository.cs
        `-- SimpleStore.Infrastructure.csproj
```

## Layer Responsibilities

- **Domain**: core entities and business rules.
- **Application**: use-case/service logic and interfaces (ports).
- **Infrastructure**: implementation details (repositories, external systems).
- **Api**: HTTP entry point and dependency injection wiring.

## Service-based flow

`ProductsController -> IProductService (ProductService) -> IProductRepository (InMemoryProductRepository)`
