
using Newtonsoft.Json;

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
        public string? Name { get; set; } // Le titre du jeu
        public string? Released { get; set; } // La date de sortie du jeu
        public string? Console { get; set; }
        public string? Genre { get; set; }
        public string? Publisher { get; set; }
        public decimal Price { get; set; }

        [JsonProperty("background_image")]
        public string? BackgroundImage { get; set; }
        // Ajoutez d'autres propriétés au besoin
    }

}
