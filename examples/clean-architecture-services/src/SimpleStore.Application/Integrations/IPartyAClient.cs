namespace SimpleStore.Application.Integrations;

public interface IPartyAClient
{
    Task<decimal> GetRecommendedPriceAsync(string productName, CancellationToken cancellationToken = default);
}
