using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete;

public class About
{
    
    public int Id { get; set; }
    
    public string AboutTitle { get; set; }
    
    public string AboutText { get; set; }
    
    public string? AboutImage { get; set; }
}