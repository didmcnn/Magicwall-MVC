using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreLayer.Helpers;

public static class HtmlHelpers
{
    public static string IsActive(this IHtmlHelper html, string controller, string action)
    {
        var routeData = html.ViewContext.RouteData.Values;
        var currentController = routeData["controller"]?.ToString();
        var currentAction = routeData["action"]?.ToString();

        return (controller == currentController && action == currentAction) ? "active" : "";
    }

    public static string IsParentActive(this IHtmlHelper html, string[] actions, string controller)
    {
        var routeData = html.ViewContext.RouteData.Values;
        var currentController = routeData["controller"]?.ToString();
        var currentAction = routeData["action"]?.ToString();

        return (controller == currentController && actions.Contains(currentAction)) ? "menu-open" : "";
    }
}
