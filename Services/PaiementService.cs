using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Travail1.Data;
using Travail1.Models;

public class PaiementService
{
    private readonly GameDbContext _context;

    public PaiementService(GameDbContext context)
    {
        _context = context;
    }


    public bool TraiterPaiement(Client client, decimal montant)
    {
        // Vérification du solde
        if (client.Solde >= montant)
        {
            try
            {
                // Déduction du montant du solde
                client.Solde -= montant;

                // Enregistrement de la transaction ou génération de la facture (à implémenter selon vos besoins)
                Facture facture = new Facture
                {
                    DateFacturation = DateTime.Now,
                    Montant = montant,
                    Client = client
                };

                // Mise à jour de la base de données
                _context.Factures.Add(facture);
                _context.SaveChanges();

                return true; // Le paiement est réussi
            }
            catch (Exception ex)
            {
                // Gérer les exceptions, enregistrez-les dans les journaux, etc.
                return false; // Le paiement a échoué en raison d'une exception
            }
        }

        return false; // Le solde n'est pas suffisant pour effectuer le paiement
    }

}
