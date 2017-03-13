using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExMobileApp.Models
{
   public class Topic
    {
        [JsonProperty("topic")]
        public string TopicName { get; set; }
        [JsonProperty("ispresented")]
        public string IsPresented { get; set; }
        [JsonProperty("submittedby")]
        public Person SubmittedBy { get; set; }
    }
}
