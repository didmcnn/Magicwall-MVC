using CoreLayer.BaseEntities;

namespace EntityLayer.Concrete;

public class About : BaseEntity<int>
{
    public string Title { get; set; }
    public string Text { get; set; }
    public string? Image { get; set; }
}