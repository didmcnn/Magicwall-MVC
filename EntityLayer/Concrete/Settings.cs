using CoreLayer.BaseEntities;

namespace EntityLayer.Concrete
{
    public class Settings: BaseEntity<int>
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
