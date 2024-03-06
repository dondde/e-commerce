using Newtonsoft.Json;
using System.Collections.Generic;

namespace Travail1.Models
{
    public class ApiResponse
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<Game> Results { get; set; }
    }

    public class Game
    {
        public int Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("released")]
        public string? Released { get; set; }

        [JsonProperty("console")]
        public string? Console { get; set; }

        [JsonProperty("genre")]
        public string? Genre { get; set; }

        [JsonProperty("publisher")]
        public string? Publisher { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("background_image")]
        public string? BackgroundImage { get; set; }

        // Propriétés de navigation
        public List<Facture> Factures { get; set; } = new List<Facture>();

        // Propriétés de la relation avec Vendeur
        public Vendeur Vendeur { get; set; }
        public string VendeurId { get; set; }

    }
}
