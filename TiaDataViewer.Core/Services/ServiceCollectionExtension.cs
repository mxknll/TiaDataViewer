using Microsoft.Extensions.DependencyInjection;

namespace TiaDataViewer.Core.Services
{
    public static class ServiceCollectionExtension
    {
        // Gets called on application startup to add services to the IoC container
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IXmlService, XmlService>();
        }
    }
}
