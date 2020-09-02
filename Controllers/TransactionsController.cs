using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BankingClientMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BankingClientMVC.Controllers
{
    public class TransactionsController : Controller
    {
        Uri baseaddress = new Uri("https://localhost:44392/api");
        HttpClient client;
        public TransactionsController()
        {
            client = new HttpClient();
            client.BaseAddress = baseaddress;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetTransaction()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Details(TransactionDetails details)
        {
            List<Transaction> transactions = new List<Transaction>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Transactions/"+details.AccNumber+"/"+details.FromDate.ToString("yyyy-MM-dd")+"/"+details.ToDate.ToString("yyyy-MM-dd")).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                transactions = JsonConvert.DeserializeObject<List<Transaction>>(data);
                return View(transactions);
            }
            return BadRequest();
        }
    }
}
