using CoreLayer.BaseEntities;
using EntityLayer.Enums;

namespace EntityLayer.Concrete;

public class PhotoPageItem:BaseEntity<int>
{
    public string Name{ get; set; }
    public string Image { get; set; }
    public PhotoItemType? ItemType { get; set; }
}