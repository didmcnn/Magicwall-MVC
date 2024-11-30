using CoreLayer.BaseEntities;

namespace EntityLayer.Concrete;

public class ModelPageItem : BaseEntity<int>
{
    public string Name { get; set; }
    public string Image { get; set; }

    public int? DetailsId { get; set; }
    public virtual ModelDetail? Details { get; set; }
}