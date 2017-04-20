using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExMobileApp.Models
{
   public class Transaction
    {
        [JsonProperty("transactionItem")]
        public Shop TransactionItem { get; set; }
        [JsonProperty("userid")]
        public string UserId { get; set; }
        [JsonProperty("Transactor")]
        public Person Transactor { get; set; }
        [JsonProperty("transactiondate")]
        public DateTime TransactionDate { get; set; }   
    }
}
