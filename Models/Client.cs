using System.Collections.Generic;

namespace Travail1.Models
{
    public class Client : User
    {
        // Attributs spécifiques au client
        public decimal Solde { get; set; }

        // Relations
        public List<Facture> Factures { get; set; } = new List<Facture>();
        public Panier Panier { get; set; } = new Panier();
    }


}
