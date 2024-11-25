using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Security.Cryptography;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class UserManager : UserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal authDal)
        {
            _userDal = authDal;
        }

        public async Task<bool> RegisterAsync(string username, string email, string password)
        {
            // Check if user exists
            User existingUser = await _userDal.GetByFilterAsync(x => x.Email == email);
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
                CreatedDate = DateTime.UtcNow
            };

            await _userDal.AddAsync(user);
            return true;
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            var user = await _userDal.GetByFilterAsync(x=>x.Email==email);
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

        public async Task DeleteUserAsync(User user)
        {
            await _userDal.DeleteAsync(user);
        }

        public async Task<User?> GetByIDAsync(int id)
        {
            return await _userDal.GetByIdAsync(id);
        }

        public async Task<User?> UpdateUserAsync(User user)
        {
            return await _userDal.UpdateAsync(user);
        }

        public async Task<User?> GetByUserNameAsync(string userName)
        {
            return await _userDal.GetByFilterAsync(x => x.Username == userName);
        }

        public async Task<User?> GetByMailAsync(string mail)
        {
            return await _userDal.GetByFilterAsync(x => x.Email == mail);
        }

        public async Task<List<User>> GetUserListAsync()
        {
            return await _userDal.GetAllAsync();
        }
    }
}
