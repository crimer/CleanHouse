using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CleanHouse.Application
{
    public static class AppDependencies
    {
        public static ServiceProvider ServiceProvider { get; private set; }

        public static void RegisterApplicationDependencies(this ServiceCollection services)
        {
            services.AddLogging(c =>
            {
                c.ClearProviders();
                c.AddDebug();
            });
        }

        public static void Build(ServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
        }
    }
}