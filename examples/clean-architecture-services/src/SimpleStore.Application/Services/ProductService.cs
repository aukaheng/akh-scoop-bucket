using SimpleStore.Application.Contracts;
using SimpleStore.Application.Repositories;
using SimpleStore.Domain.Entities;

namespace SimpleStore.Application.Services;

public sealed class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IReadOnlyList<ProductDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var products = await _productRepository.GetAllAsync(cancellationToken);
        return products.Select(Map).ToList();
    }

    public async Task<ProductDto> CreateAsync(string name, decimal price, CancellationToken cancellationToken = default)
    {
        var product = new Product(name, price);
        await _productRepository.AddAsync(product, cancellationToken);
        return Map(product);
    }

    private static ProductDto Map(Product product) => new(product.Id, product.Name, product.Price);
}
