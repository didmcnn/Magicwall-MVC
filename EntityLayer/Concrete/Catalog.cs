using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete;

public class Catalog
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PDF { get; set; }
}