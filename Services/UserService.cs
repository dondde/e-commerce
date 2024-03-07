using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Travail1.Data;
using Travail1.Models;

namespace Travail1.Services
{
    public class UserService
    {
        private readonly GameDbContext _context;

        public UserService(GameDbContext context)
        {
            _context = context;
        }

        public User GetUserById(int userId)
        {
            return _context.Users.FirstOrDefault(u => u.Id == userId);
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public bool AuthenticateUser(string email, string password)
        {
            User user = GetUserByEmail(email);

            if (user != null)
            {
                // Vérifier le mot de passe en le comparant avec le hachage stocké
                string hashedPassword = HashPassword(password, user.Id.ToString());

                return user.PasswordHash == hashedPassword;
            }

            return false;
        }

        public void RegisterUser(User newUser)
        {
            // Hacher le mot de passe avant de le stocker en base de données
            newUser.PasswordHash = HashPassword(newUser.PasswordHash, newUser.Id.ToString());

            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        // Autres méthodes liées aux utilisateurs

        private string HashPassword(string password, string salt)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Concaténer le mot de passe avec le sel et hacher le résultat
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password + salt));

                // Convertir le tableau de bytes en une chaîne hexadécimale
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}
