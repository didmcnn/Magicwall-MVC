using CoreLayer.BaseEntities;

namespace EntityLayer.Concrete;

public class Catalog:BaseEntity<int>
{
    public string Name { get; set; }
    public string PDF { get; set; }
}