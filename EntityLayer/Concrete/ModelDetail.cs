
using CoreLayer.BaseEntities;

namespace EntityLayer.Concrete;

public class ModelDetail:BaseEntity<int>
{
    public string Description { get; set; }
    public string ModelNo { get; set; }
    public string Thickness { get; set; }
    public string SideLength { get; set; }
    public string Measurements { get; set; }
    public string Weight { get; set; }
    public string Material { get; set; }
    public string UsableEnviroments { get; set; }


    public string FireResistance { get; set; }
    public string DimentionTolerance { get; set; }
    public string HeatResistance { get; set; }
    public string ThicknesTolerance { get; set; }


    public int ModelPageItemId { get; set; }
    public ModelPageItem ModelPageItem { get; set; }

    public virtual ICollection<ModelImage>? ModelImages { get; set; }
}
