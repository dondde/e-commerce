using System;
using System.ComponentModel.DataAnnotations;

namespace Travail1.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le champ Nom est obligatoire.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Le champ Prénom est obligatoire.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Le champ Adresse est obligatoire.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Le champ Email est obligatoire.")]
        [EmailAddress(ErrorMessage = "Veuillez entrer une adresse e-mail valide.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le champ Date de naissance est obligatoire.")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Le champ Ville est obligatoire.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Le champ Mot de passe est obligatoire.")]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }

        [Compare("PasswordHash", ErrorMessage = "Les mots de passe ne correspondent pas.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Le champ Type de profil est obligatoire.")]
        public bool IsSeller { get; set; }

    }
}
