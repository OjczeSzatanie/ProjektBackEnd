using Client_cik.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Client_cik.Controllers
{
    public class MoviesController : Controller
    {
        public static string baseUrl = "https://localhost:7020/Movies";

        public async Task<IActionResult> Index()
        {
            var movies = await GetAllMoviesAsync();
            return View(movies);
        }

        [HttpGet]
        public async Task<List<Movies>> GetAllMoviesAsync()
        {
            var accessToken = HttpContext.Session.GetString("JWToken");
            var url = baseUrl;

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            string jsonStr = await client.GetStringAsync(url);

            var res = JsonConvert.DeserializeObject<List<Movies>>(jsonStr).ToList();

            return res;
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMovie([Bind("Id,Title,Duration,Genre,Image")] Movies movies)
        {

            var accessToken = HttpContext.Session.GetString("JWToken");
            var url = baseUrl;

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var stringContent = new StringContent(JsonConvert.SerializeObject(movies), Encoding.UTF8, "application/json");

            await client.PostAsync(url, stringContent);

            return  RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMovie(Guid? id, [Bind("Id,Title,Duration,Genre,Image") ] Movies movies)
        {
            if(id != movies.Id)
            {
                return NotFound();
            }
            var accessToken = HttpContext.Session.GetString("JWToken");
            var url = baseUrl + id;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            

            var stringContent = new StringContent(JsonConvert.SerializeObject(movies), Encoding.UTF8, "application/json");
            await client.PostAsync(url, stringContent);
            return RedirectToAction(nameof(Index));


        }
    }
}
