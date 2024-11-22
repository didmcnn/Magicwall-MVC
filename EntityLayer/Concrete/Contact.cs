using CoreLayer.BaseEntities;

namespace EntityLayer.Concrete;

public class Contact:BaseEntity<int>
{
    public string ContactName { get; set; }
    
    public string ContactSurname { get; set; }
    
    public string ContactEmail { get; set; }
    
    public string ContactMessage { get; set; }
    
    public string MapLocation { get; set; }
}