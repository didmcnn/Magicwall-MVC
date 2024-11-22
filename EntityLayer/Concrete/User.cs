using CoreLayer.BaseEntities;

namespace EntityLayer.Concrete;

public class User:BaseEntity<int>
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
}
