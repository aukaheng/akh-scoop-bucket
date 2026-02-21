using SimpleStore.Application.Abstractions;
using SimpleStore.Domain.Entities;

namespace SimpleStore.Infrastructure.Persistence;

public sealed class InMemoryProductRepository : IProductRepository
{
    private readonly List<Product> _products = new();

    public Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult<IReadOnlyList<Product>>(_products.ToList());
    }

    public Task AddAsync(Product product, CancellationToken cancellationToken = default)
    {
        _products.Add(product);
        return Task.CompletedTask;
    }
}
