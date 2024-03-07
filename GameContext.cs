using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Travail1.Models;

namespace Travail1.Data
{
    public class GameDbContext : IdentityDbContext<User>
    {
        public GameDbContext(DbContextOptions<GameDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Panier> Paniers { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Facture> Factures { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Vendeur> Vendeurs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection_string = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            string database_Game = "Game";
            optionsBuilder.UseSqlServer($"{connection_string};Database={database_Game};");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration spécifique à Vendeur
            modelBuilder.Entity<Vendeur>()
                .Property(v => v.MontantVentes)
                .HasColumnType("DECIMAL(18,2)"); // Vous pouvez ajuster le type de données en fonction de vos besoins

            modelBuilder.Entity<Game>()
                .HasOne(g => g.Vendeur)
                .WithMany(v => v.Games)
                .HasForeignKey(g => g.VendeurId)
                .OnDelete(DeleteBehavior.Restrict); // Adjust cascade behavior as needed

            // Configuration de la relation entre Facture et Client
            modelBuilder.Entity<Facture>()
                .HasOne(f => f.Client)
                .WithMany(c => c.Factures)
                .HasForeignKey(f => f.ClientId)
                .OnDelete(DeleteBehavior.Restrict); // Adjust cascade behavior as needed
        }

        internal object GetClientByUsername(string? name)
        {
            throw new NotImplementedException();
        }

        internal string? GetGames()
        {
            throw new NotImplementedException();
        }

        internal string? GetVendeurByUsername(string? name)
        {
            throw new NotImplementedException();
        }
    }
}
