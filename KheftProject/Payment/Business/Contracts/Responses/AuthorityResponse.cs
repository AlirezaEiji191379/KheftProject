using Newtonsoft.Json;

namespace KheftProject.Payment.Business.Contracts.Responses;

public record AuthorityResponse
{
    [JsonProperty("data")]
    public AuthorityData Data { get; init; }
    //TODO : check Errors in zarin pall api
    [JsonProperty("errors")]
    public List<string> Errors { get; set; }
}


public record AuthorityData
{
    [JsonProperty("code")]
    public int Code { get; init; }
    [JsonProperty("message")]
    public string Message { get; init; }
    [JsonProperty("authority")]
    public string Authority { get; init; }
    
}
