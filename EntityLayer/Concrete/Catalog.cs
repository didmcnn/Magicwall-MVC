using CoreLayer.BaseEntities;

namespace EntityLayer.Concrete;

public class Catalog:BaseEntity<int>
{
    public string PDF { get; set; }
}