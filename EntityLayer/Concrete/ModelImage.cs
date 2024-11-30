using CoreLayer.BaseEntities;
using EntityLayer.Enums;

namespace EntityLayer.Concrete;

public class ModelImage : BaseEntity<int>
{
    public ModelImageType Type { get; set; }
    public string Path { get; set; }

    public int ModelDetailId { get; set; }
    public ModelDetail ModelDetail { get; set; }
}
