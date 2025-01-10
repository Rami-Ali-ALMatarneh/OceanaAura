using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OceanaAura.Application.Contracts.RenderView;

namespace OceanaAura.Infrastructure.RenderServices
{
    public class ViewRenderService : IViewRenderService
    {
        private readonly IServiceProvider _serviceProvider;

        public ViewRenderService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task<string> RenderToStringAsync(string viewName, object model)
        {
            var httpContext = new DefaultHttpContext { RequestServices = _serviceProvider };
            var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());

            using var stringWriter = new StringWriter();
            var viewResult = _serviceProvider
                .GetRequiredService<IViewEngine>()
                .FindView(actionContext, viewName, false);

            if (!viewResult.Success)
            {
                throw new InvalidOperationException($"View {viewName} not found");
            }

            var viewContext = new ViewContext(
                actionContext,
                viewResult.View,
                new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                {
                    Model = model
                },
                new TempDataDictionary(actionContext.HttpContext, _serviceProvider.GetRequiredService<ITempDataProvider>()),
                stringWriter,
                new HtmlHelperOptions()
            );
            await viewResult.View.RenderAsync(viewContext);
            return stringWriter.ToString();
        }
    }
}
