using System;
using System.Collections.Generic;

namespace Travail1.Models
{
    public class Facture
    {
        public int Id { get; set; }
        public DateTime DateFacturation { get; set; }
        public decimal Montant { get; set; }
        public List<Game> ArticlesAchetes { get; set; } = new List<Game>();

        // Propriétés de clé étrangère
        public string ClientId { get; set; }
        public int VendeurId { get; set; }

        // Propriétés de navigation
        public User Client { get; set; }
        public Vendeur Vendeur { get; set; }
    }
}
