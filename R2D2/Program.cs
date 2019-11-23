using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using R2D2.Calculator;
using R2D2.Interfaces;
using R2D2.Parser;

namespace R2D2
{
    internal static class Program
    {
        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<Startup>();
            services.AddTransient<IExpressionParser, ExpressionParser>();
            services.AddTransient<IExpressionCalculator, ExpressionCalculator>();
            services.AddMemoryCache();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
        private static async Task Main()
        {
            var services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();
            await serviceProvider.GetService<Startup>().Run();
        }
    }
}