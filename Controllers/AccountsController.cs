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
    public class AccountsController : Controller
    {
        Uri baseaddress = new Uri("https://localhost:44392/api");
        HttpClient client;
        public AccountsController()
        {
            client = new HttpClient();
            client.BaseAddress = baseaddress;
        }
        public IActionResult Index()
        {
            List<Account> accounts = new List<Account>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Accounts").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                accounts = JsonConvert.DeserializeObject<List<Account>>(data);
                return View(accounts);
            }
            return View();
        }
        public IActionResult NewAccount()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Account obj)
        {
            string data = JsonConvert.SerializeObject(obj);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/Accounts", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
