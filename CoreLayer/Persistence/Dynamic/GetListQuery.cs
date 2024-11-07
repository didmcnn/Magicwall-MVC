using CoreLayer.Persistence.Request;

namespace CoreLayer.Persistence.Dynamic;

public class GetListQuery
{
    public PageRequest PageRequest { get; set; }
    public Dynamic Dynamic { get; set; }
}
