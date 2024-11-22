using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract;

public interface IAuthDal
{
    Task<User> GetUserByEmailAsync(string email);
    Task AddUserAsync(User user);
}
