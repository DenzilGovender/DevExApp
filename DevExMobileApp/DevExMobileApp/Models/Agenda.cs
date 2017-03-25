using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExMobileApp.Models
{
   public class Agenda
    {
        [JsonProperty("venue")]
        public string Venue { get; set; }
        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("sessions")]
        public List<Session> Sessions { get; set; }
    }
}
