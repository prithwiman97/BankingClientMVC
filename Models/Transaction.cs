using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingClientMVC.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int FromAccount { get; set; }
        public int ToAccount { get; set; }
        public DateTime DOT { get; set; }
        public string Type { get; set; }
        public double Amount { get; set; }
        public double FinalBalance { get; set; }
    }
}
