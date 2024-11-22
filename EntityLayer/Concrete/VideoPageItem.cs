using CoreLayer.BaseEntities;

namespace EntityLayer.Concrete;

public class VideoPageItem:BaseEntity<int>
{
    public string Name{ get; set; }
    public string Video { get; set; }
}