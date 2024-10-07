
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace MultiShop.WebUI.Utilities.RazorViewRendererHelper
{
    public class RazorViewRendererHelper : IRazorViewRenderer
    {
        private readonly IRazorViewEngine _engine;
        private readonly ITempDataProvider _tempDataProvider;
        private readonly IServiceProvider _provider;

        public RazorViewRendererHelper(IRazorViewEngine engine, ITempDataProvider tempDataProvider, IServiceProvider provider)
        {
            _engine = engine;
            _tempDataProvider = tempDataProvider;
            _provider = provider;
        }

        public async Task<string> RenderRazorViewToStringAsync(string viewName, object model)
        {
            var defaultHttpContext = new DefaultHttpContext { RequestServices = _provider };
            var actionContext = new ActionContext(defaultHttpContext, new RouteData(), new ActionDescriptor());

            using (var sw = new StringWriter())
            {
                var viewResult = _engine.FindView(actionContext, viewName, false);

                if (viewResult == null)
                {
                    throw new Exception("Aradığınız Razor Sayfası Bulunamadı!");
                }

                var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                {
                    Model = model
                };

                var viewContext = new ViewContext(
                    actionContext,
                    viewResult.View,
                    viewDictionary,
                    new TempDataDictionary(actionContext.HttpContext, _tempDataProvider),
                    sw,
                    new HtmlHelperOptions()
                    );

                await viewResult.View.RenderAsync(viewContext);

                return sw.ToString();
            }
        }
    }
}
