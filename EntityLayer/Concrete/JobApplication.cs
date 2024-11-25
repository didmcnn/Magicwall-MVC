using CoreLayer.BaseEntities;

namespace EntityLayer.Concrete;

public class JobApplication:BaseEntity<int>
{
    
    public string FirstName { get; set; }   
    
    public string LastName { get; set; }
    
    public string Email { get; set; }
    
    public string Phone { get; set; }

    public string CVFile { get; set; }
    
    public string Message { get; set; }

    public OpenPosition OpenPosition { get; set; }

    
    
}