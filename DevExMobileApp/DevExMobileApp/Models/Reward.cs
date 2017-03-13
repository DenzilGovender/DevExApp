using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExMobileApp.Models
{
   public class Reward
    {
        [JsonProperty("kudos")]
        public int Kudos { get; set; }
        [JsonProperty("sessionsattended")]
        public int NoOfSessionsAttended { get; set; }
        [JsonProperty("sessionspresented")]
        public int NoOfSessionsPresented { get; set; }
        [JsonProperty("rewardee")]
        public Person Rewardee { get; set; }
    }
}
