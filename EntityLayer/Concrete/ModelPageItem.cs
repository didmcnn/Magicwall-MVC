using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete;

public class ModelPageItem
{
    public int Id { get; set; }
    public string Name{ get; set; }
    
    public string Image { get; set; }
}