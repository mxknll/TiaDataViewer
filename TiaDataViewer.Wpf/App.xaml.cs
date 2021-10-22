using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System.Windows;
using TiaDataViewer.Core.Services;

namespace TiaDataViewer.Wpf
{
    public partial class App : Application
    {
        public App()
        {
            ConfigureServices();
        }

        private static void ConfigureServices()
        {
            ServiceCollection services = new();
            services.AddCoreServices();

            Ioc.Default.ConfigureServices(
            services
            .BuildServiceProvider());
        }
    }


}
