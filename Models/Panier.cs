using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Travail1.Models
{
    public class Panier
    {
        [Key]
        public int PanierId { get; set; }

        // Attributs
        public List<Game> ArticlesDansPanier { get; set; } = new List<Game>();

        // Méthodes
        public void AjouterAuPanier(Game article)
        {
            ArticlesDansPanier.Add(article);
        }

        public void RetirerDuPanier(Game article)
        {
            ArticlesDansPanier.Remove(article);
        }

        public void ViderPanier()
        {
            ArticlesDansPanier.Clear();
        }
    }
}
