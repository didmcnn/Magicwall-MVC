using CoreLayer.BaseEntities;
using System;

namespace EntityLayer.Concrete;

public class HomePageItem:BaseEntity<int>
{
    public string Title { get; set; }
    public string Text { get; set; }
    public string? Image { get; set; }
    
}
