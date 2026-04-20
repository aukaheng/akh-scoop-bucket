using System.Net.Http.Json;
using SimpleStore.Application.Integrations;
using SimpleStore.Infrastructure.Integrations.PartyA.Contracts;

namespace SimpleStore.Infrastructure.Integrations.PartyA;

public sealed class PartyAClient : IPartyAClient
{
    private readonly HttpClient _httpClient;

    public PartyAClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<decimal> GetRecommendedPriceAsync(string productName, CancellationToken cancellationToken = default)
    {
        var request = new PartyAPriceRequest(productName);

        using var response = await _httpClient.PostAsJsonAsync(
            "v1/pricing/recommend",
            request,
            cancellationToken);

        response.EnsureSuccessStatusCode();

        var payload = await response.Content.ReadFromJsonAsync<PartyAPriceResponse>(cancellationToken: cancellationToken);
        if (payload is null)
        {
            throw new InvalidOperationException("PartyA response body is empty.");
        }

        return payload.RecommendedPrice;
    }
}
