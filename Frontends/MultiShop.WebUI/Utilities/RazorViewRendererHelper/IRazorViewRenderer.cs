namespace MultiShop.WebUI.Utilities.RazorViewRendererHelper
{
    public interface IRazorViewRenderer
    {
        Task<string> RenderRazorViewToStringAsync(string viewName, object model);
    }
}
