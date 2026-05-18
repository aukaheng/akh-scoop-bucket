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
    |   |-- Contracts/
    |   |   `-- ProductDto.cs
    |   |-- Integrations/
    |   |   `-- IPartyAClient.cs
    |   |-- Repositories/
    |   |   `-- IProductRepository.cs
    |   |-- Services/
    |   |   |-- IProductService.cs
    |   |   `-- ProductService.cs
    |   `-- SimpleStore.Application.csproj
    |-- SimpleStore.Domain/
    |   |-- Entities/
    |   |   `-- Product.cs
    |   `-- SimpleStore.Domain.csproj
    `-- SimpleStore.Infrastructure/
        |-- Integrations/
        |   `-- PartyA/
        |       |-- Contracts/
        |       |   |-- PartyAPriceRequest.cs
        |       |   `-- PartyAPriceResponse.cs
        |       `-- PartyAClient.cs
        |-- Persistence/
        |   `-- InMemoryProductRepository.cs
        `-- SimpleStore.Infrastructure.csproj
```

## Layer Responsibilities

- **Domain**: core entities and business rules.
- **Application**: use-case/service logic and interfaces (ports for repositories and integrations).
- **Infrastructure**: implementation details (repositories, external systems).
- **Api**: HTTP entry point and dependency injection wiring.

## Service-based flow

`ProductsController -> IProductService (ProductService) -> IProductRepository (InMemoryProductRepository)`

When `price <= 0`, `ProductService` also calls:

`IProductService (ProductService) -> IPartyAClient (PartyAClient)`

## External REST API placement

- Put third-party REST request/response classes in **Infrastructure** (integration details).
- Keep a port interface in **Application** (for example `IPartyAClient`).
- Keep **Domain** free of provider-specific payload models.

## Rule of thumb

- **Database-related persistence** -> usually a **Repository** interface in Application + implementation in Infrastructure.
- **External REST/API communication** -> usually an **Integration client/gateway** interface in Application + implementation and contracts in Infrastructure.
