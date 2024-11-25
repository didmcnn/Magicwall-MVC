using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Magicwall.ViewComponents.CatalogComponent;

public class CatalogComponent : ViewComponent
{
    private readonly ICatalogService _catalogService;
    public CatalogComponent(ICatalogService catalogService)
    {
        _catalogService= catalogService;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        List<Catalog> catalog = await _catalogService.GetAllAsync();
        if (catalog.Count>0)
        {
            return View(catalog.First());
        }
        else
        {
            return View(new Catalog(){});
        }
    }
}
