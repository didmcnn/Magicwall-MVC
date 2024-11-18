using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete;

public class VideoPageItem
{
    public int Id { get; set; }
    public string Name{ get; set; }
    
    public string Video { get; set; }
}