using Microsoft.AspNetCore.Mvc;
using Travail1.Data;
using Travail1.Models;

public class VendeurController : Controller
{
    private readonly GameDbContext _context;

    public VendeurController(GameDbContext context)
    {
        _context = context;
    }

    // Action pour afficher la page de gestion des articles par le vendeur
    public IActionResult GererArticles()
    {
        var articles = _context.GetGames(); // Supposons que vous ayez une méthode GetGames dans votre contexte
        return View(articles);
    }

    // Action pour afficher le profil du vendeur
    public IActionResult Profil()
    {
        // Récupérez les informations du vendeur actuellement connecté, par exemple, à partir du contexte utilisateur
        var vendeur = _context.GetVendeurByUsername(User.Identity.Name); // Supposons que vous ayez une méthode GetVendeurByUsername dans votre contexte
        return View(vendeur);
    }

    // Action pour afficher les statistiques de ventes du vendeur
    public IActionResult StatistiquesVentes()
    {
        // Récupérez les informations du vendeur actuellement connecté, par exemple, à partir du contexte utilisateur
        var vendeur = _context.GetVendeurByUsername(User.Identity.Name); // Supposons que vous ayez une méthode GetVendeurByUsername dans votre contexte
        return View(vendeur);
    }

    // Autres actions liées aux fonctionnalités du vendeur
}
