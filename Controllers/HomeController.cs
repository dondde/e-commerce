using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Travail1.Data;
using Travail1.Models;

namespace Travail1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly GameDbContext _context;

        // Injectez IHttpClientFactory dans le constructeur pour gérer HttpClient de manière plus efficace.
        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // Méthode pour la page d'accueil
        public async Task<IActionResult> Accueil()
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var response = await httpClient.GetAsync("https://api.rawg.io/api/games?key=438744809eed406f8b4d16c6574f6952");

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(content);

                        return View(apiResponse.Results);
                    }
                    else
                    {
                        return View("Error");
                    }
                }
            }
            catch (Exception ex)
            {
                // Gérer l'exception, par exemple, en enregistrant dans les journaux
                return View("Error");
            }
        }
    }
}
