using CoreLayer.BaseEntities;

namespace EntityLayer.Concrete;

public class DocumentsPageItem:BaseEntity<int>
{
    public string Name{ get; set; }
    public string Image { get; set; }
}