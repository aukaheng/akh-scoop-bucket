using SimpleStore.Application.Contracts;
using SimpleStore.Application.Integrations;
using SimpleStore.Application.Repositories;
using SimpleStore.Domain.Entities;

namespace SimpleStore.Application.Services;

public sealed class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IPartyAClient _partyAClient;

    public ProductService(IProductRepository productRepository, IPartyAClient partyAClient)
    {
        _productRepository = productRepository;
        _partyAClient = partyAClient;
    }

    public async Task<IReadOnlyList<ProductDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var products = await _productRepository.GetAllAsync(cancellationToken);
        return products.Select(Map).ToList();
    }

    public async Task<ProductDto> CreateAsync(string name, decimal price, CancellationToken cancellationToken = default)
    {
        var resolvedPrice = price;
        if (resolvedPrice <= 0)
        {
            resolvedPrice = await _partyAClient.GetRecommendedPriceAsync(name, cancellationToken);
        }

        var product = new Product(name, resolvedPrice);
        await _productRepository.AddAsync(product, cancellationToken);
        return Map(product);
    }

    private static ProductDto Map(Product product) => new(product.Id, product.Name, product.Price);
}
