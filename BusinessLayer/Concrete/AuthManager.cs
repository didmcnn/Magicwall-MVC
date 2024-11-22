using BusinessLayer.Abstaract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Security.Cryptography;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IAuthDal _authDal;

        public AuthManager(IAuthDal authDal)
        {
            _authDal = authDal;
        }

        public async Task<bool> RegisterAsync(string username, string email, string password)
        {
            // Check if user exists
            var existingUser = await _authDal.GetUserByEmailAsync(email);
            if (existingUser != null)
                return false;

            // Hash password
            var passwordHash = HashPassword(password);

            // Create and save user
            var user = new User
            {
                Username = username,
                Email = email,
                PasswordHash = passwordHash,
                CreatedAt = DateTime.UtcNow
            };

            await _authDal.AddUserAsync(user);
            return true;
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            var user = await _authDal.GetUserByEmailAsync(email);
            if (user == null)
                return false;

            return VerifyPassword(password, user.PasswordHash);
        }

        private static string HashPassword(string password)
        {
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = SHA256.HashData(bytes);
            return Convert.ToBase64String(hash);
        }

        private static bool VerifyPassword(string password, string passwordHash)
        {
            var hash = HashPassword(password);
            return hash == passwordHash;
        }
    }
}
