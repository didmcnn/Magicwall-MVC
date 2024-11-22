using EntityLayer.Concrete;

namespace BusinessLayer.Abstaract
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(string username, string email, string password);
        Task<bool> LoginAsync(string email, string password);

        Task DeleteUserAsync(User user);
        Task<User?> GetByIDAsync(int id);
        Task<User?> UpdateUserAsync(User user);
        Task<User?> GetByUserNameAsync(string userName);
        Task<User?> GetByMailAsync(string mail);
        Task<List<User>> GetUserListAsync();
    }
}
