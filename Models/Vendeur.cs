using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Travail1.Models
{
    public class Vendeur : User
    {
        [Required(ErrorMessage = "Le champ Statut Vendeur est obligatoire.")]
        public string? StatutVendeur { get; set; }

        public List<Game> ArticlesEnVente { get; set; } = new List<Game>();
        public List<Game> ArticlesVendus { get; set; } = new List<Game>();
        public decimal MontantVentes { get; set; }

        public List<Game>? Games { get; set; } = new List<Game>();
    }
}
