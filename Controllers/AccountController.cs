using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Travail1.Models;
using System;

public class AccountController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    // Action pour afficher le formulaire d'inscription
    public IActionResult Inscription()
    {
        return View();
    }

    // Action pour traiter le formulaire d'inscription
    [HttpPost]
    public async Task<IActionResult> Enregistrer(User model)
    {
        if (ModelState.IsValid)
        {
            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                Email = model.Email,
                DateOfBirth = model.DateOfBirth,
                City = model.City,
                IsSeller = model.IsSeller
            };

            var result = await _userManager.CreateAsync(user, model.PasswordHash);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);

                // Redirection en fonction du type de profil
                if (model.IsSeller)
                {
                    // Ajoutez un message de débogage
                    Console.WriteLine("Redirection vers le profil du vendeur");
                    return RedirectToAction("Profil", "Vendeur");
                }
                else
                {
                    // Ajoutez un message de débogage
                    Console.WriteLine("Redirection vers le profil du client");
                    return RedirectToAction("Profil", "Client");
                }
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
        }

        return View("Inscription", model);
    }

    // Autres actions pour la gestion des utilisateurs
}
