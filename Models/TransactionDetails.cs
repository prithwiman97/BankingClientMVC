using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingClientMVC.Models
{
    public class TransactionDetails
    {
        public int AccNumber { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
