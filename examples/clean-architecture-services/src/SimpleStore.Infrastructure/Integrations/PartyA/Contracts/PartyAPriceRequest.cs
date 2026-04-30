using System.Text.Json.Serialization;

namespace SimpleStore.Infrastructure.Integrations.PartyA.Contracts;

public sealed record PartyAPriceRequest(
    [property: JsonPropertyName("product_name")] string ProductName);
