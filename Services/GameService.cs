using System.Collections.Generic;
using Travail1.Data;
using Travail1.Models;

public class GameService
{
    private readonly GameDbContext _context;

    public GameService(GameDbContext context)
    {
        _context = context;
    }

    public List<Game> GetAvailableGames()
    {
        // Récupérez la liste des jeux disponibles depuis la base de données
        return _context.Games.ToList();
    }

    public Game GetGameById(int gameId)
    {
        return _context.Games.Find(gameId);
    }

    // Ajoutez d'autres méthodes liées aux jeux au besoin
}
