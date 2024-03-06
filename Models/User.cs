using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travail1.Models
{
    public class User : IdentityUser
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le champ Nom est obligatoire.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le champ Prénom est obligatoire.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le champ Adresse est obligatoire.")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le champ Email est obligatoire.")]
        [EmailAddress(ErrorMessage = "Veuillez entrer une adresse e-mail valide.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le champ Date de naissance est obligatoire.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Le champ Ville est obligatoire.")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le champ Mot de passe est obligatoire.")]
        [DataType(DataType.Password)]
        public override string PasswordHash { get; set; } = string.Empty;

        [NotMapped] // Ne sera pas mappé à la base de données
        [Compare("PasswordHash", ErrorMessage = "Les mots de passe ne correspondent pas.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le champ Type de profil est obligatoire.")]
        public bool IsSeller { get; set; }

        public List<Facture> Factures { get; set; } = new List<Facture>();
        public Panier Panier { get; set; }
    }
}
