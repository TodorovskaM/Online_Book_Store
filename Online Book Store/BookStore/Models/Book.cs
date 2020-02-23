using Newtonsoft.Json;

namespace BookStore.Models
{
    public class Book
    {
        [JsonProperty("id")]
        public int BookId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("stock")]
        public int Stock { get; set; }

        [JsonProperty("category id")]
        public int CategoryId { get; set; }
    }
}
