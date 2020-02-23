using Newtonsoft.Json;
using System;

namespace BookStore.Models
{
    public class Customers
    {
        [JsonProperty("customer id")]
        public int CustomerId { get; set; }

        [JsonProperty("first name")]
        public string FirstName { get; set; }

        [JsonProperty("last name")]
        public string LastName { get; set; }

        [JsonProperty("birth date")]
        public DateTime BirthDate { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("phone number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        public string Role { get; set; }
    }
}
