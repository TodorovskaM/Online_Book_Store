using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;


namespace BookStore.Models
{
    public class Category
    {
        [JsonProperty("id")]
        public int CategoryId { get; set; }

        [JsonProperty("category")]
        public string CategoryName { get; set; }
    }
}
