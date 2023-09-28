using Newtonsoft.Json;

namespace KheftProject.Book.Business.Contracts.Dtos
{
    public class AcceptBookResponse
    {
        [JsonProperty("book")]
        public BookDto Book { get; init; }
        [JsonProperty("bookOwner")]
        public Owner BookOwner { get; init; }
    }

    public class BookDto
    {
        [JsonProperty("id")]
        public Guid Id { get; init; }
        [JsonProperty("isAccepted")]
        public bool IsAccepted { get; init; }
        [JsonProperty("name")]
        public string Name { get; init; }
        [JsonProperty("description")]
        public string Description { get; init; }
    }

    public class Owner
    {
        [JsonProperty("fullName")]
        public string FullName { get; init; }
        [JsonProperty("telegramUsername")]
        public string TelegramUsername { get; init; }
        [JsonProperty("telegramSerialId")]
        public long TelegramSerialId { get; init; }
    }
}
