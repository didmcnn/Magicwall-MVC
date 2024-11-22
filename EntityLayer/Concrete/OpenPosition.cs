using CoreLayer.BaseEntities;

namespace EntityLayer.Concrete;

public class OpenPosition:BaseEntity<int>
{
    public string Name { get; set; }
}