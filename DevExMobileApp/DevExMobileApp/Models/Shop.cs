using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExMobileApp.Models
{
    public class Shop
    {
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("picture")]
        public string Picture { get; set; }
        [JsonProperty("price")]
        public string Price { get; set; }
        [JsonProperty("product")]
        public string Product { get; set; }
    }
}
