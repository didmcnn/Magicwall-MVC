using CoreLayer.BaseEntities;

namespace EntityLayer.Concrete;

public class Contact:BaseEntity<int>
{
    public string Name { get; set; }
    
    public string Surname { get; set; }
    
    public string Email { get; set; }
    public string Phone { get; set; }

    public string Message { get; set; }
}