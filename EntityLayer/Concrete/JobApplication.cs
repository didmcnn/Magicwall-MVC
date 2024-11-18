using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete;

public class JobApplication
{
    public int Id { get; set; }
    
    public string FirstName { get; set; }   
    
    public string LastName { get; set; }
    
    public string Email { get; set; }
    
    public string Phone { get; set; }

    public string CVFile { get; set; }
    
    public string Message { get; set; }
    
    public int OpenPositionId { get; set; }

    public OpenPosition OpenPosition { get; set; }

    
    
}