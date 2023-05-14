using Lab6_PIS.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Lab6_PIS.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient httpClient;
        public HomeController()
        {
            httpClient = new HttpClient();
        }

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await httpClient.GetAsync("https://gorest.co.in/public/v2/users");

            response.EnsureSuccessStatusCode();

            string jsonResponse = await response.Content.ReadAsStringAsync();

            IEnumerable<User> users = JsonConvert.DeserializeObject<IEnumerable<User>>(jsonResponse) ?? new List<User>();

            return View(users);
        }
    }
}