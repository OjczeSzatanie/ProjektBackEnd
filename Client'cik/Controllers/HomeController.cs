using Client_cik.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;

namespace Client_cik.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task <IActionResult> Index()
        {
            //Calling the web API and populating data in view
          
            return View();
        }

        public async Task<IActionResult> LoginUser(UserInfo user)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent stringContent = new StringContent(JsonConvert.SerializeObject(user),Encoding.UTF8,"application/json");

                using (var response = await httpClient.PostAsync("https://localhost:7020/AuthContoller/login", stringContent))
                {
                    string token = await response.Content.ReadAsStringAsync();
                    if(token=="Invalid credentials")
                    {
                        ViewBag.Message = "Incorrent username or password";
                            return Redirect("~/Home/Index");
                    }
                    HttpContext.Session.SetString("JWToken", token);
                }
                return Redirect("~/Dashboard/Index");
            }
        }


        public IActionResult LogOff()
        {
            HttpContext.Session.Clear();
            return Redirect("~/Home/Index");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}