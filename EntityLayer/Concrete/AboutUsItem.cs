using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete;

public class AboutUsItem
{
    
    public int Id { get; set; }
    
    public string AboutUsTitle { get; set; }
    
    public string AboutUsText { get; set; }
    
    public string? AboutUsImage { get; set; }
}