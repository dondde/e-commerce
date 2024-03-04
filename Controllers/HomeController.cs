using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Travail1.Models;

namespace Travail1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

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

        // Page d'index
        public IActionResult Index()
        {
            return View();
        }

        // Page d'authentification
        public IActionResult Authentification()
        {
            return View();
        }

        // Page d'inscription
        public IActionResult Inscription()
        {
            return View();
        }

        // Traitement du formulaire d'inscription
        [HttpPost]
        public IActionResult Enregistrer(User user)
        {
            if (ModelState.IsValid)
            {
                // Ajoutez la logique d'enregistrement de l'utilisateur dans la base de données ici
                // Redirigez en fonction du type d'utilisateur
                if (user.IsSeller)
                {
                    return RedirectToAction("Profil", "Vendeur");
                }
                else
                {
                    return RedirectToAction("Profil", "Client");
                }
            }

            // Si le modèle n'est pas valide, redirigez vers la vue d'inscription avec les erreurs
            return View("Inscription", user);
        }
    }
}
