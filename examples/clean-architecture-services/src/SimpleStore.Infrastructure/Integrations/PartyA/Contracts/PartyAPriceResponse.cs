using System.Text.Json.Serialization;

namespace SimpleStore.Infrastructure.Integrations.PartyA.Contracts;

public sealed record PartyAPriceResponse(
    [property: JsonPropertyName("recommended_price")] decimal RecommendedPrice);
