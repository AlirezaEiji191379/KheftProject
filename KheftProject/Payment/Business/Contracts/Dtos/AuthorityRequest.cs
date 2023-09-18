using Newtonsoft.Json;

namespace KheftProject.Payment.Business.Contracts.Dtos;

public class AuthorityRequest
{
    [JsonProperty("merchant_id")]
    public string MerchantId { get; init; }
    [JsonProperty("amount")]
    public decimal Amount { get; init; }
    [JsonProperty("callback_url")]
    public string CallBackUrl { get; init; }
}