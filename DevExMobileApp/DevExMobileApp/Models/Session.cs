using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExMobileApp.Models
{
   public class Session
    {
        [JsonProperty("picture")]
        public string Picture { get; set; }
        [JsonProperty("speaker")]
        public string Speaker { get; set; }
        [JsonProperty("summary")]
        public string Summary { get; set; }
        [JsonProperty("topic")]
        public string Topic { get; set; }
    }
}
