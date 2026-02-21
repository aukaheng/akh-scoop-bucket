using SimpleStore.Application.Contracts;

namespace SimpleStore.Application.Abstractions;

public interface IProductService
{
    Task<IReadOnlyList<ProductDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<ProductDto> CreateAsync(string name, decimal price, CancellationToken cancellationToken = default);
}
