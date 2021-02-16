using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tracker.Contracts.Tracking;
using Tracker.Infrastructure.Services.Tracking;

namespace Tracker.Infrastructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection serviceCollection, 
            IConfiguration configuration)
        {
            AddContracts(serviceCollection, configuration);
            MapConnectionStrings(serviceCollection, configuration);
            return serviceCollection;
        }
        private static IServiceCollection AddContracts(this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection.AddTransient<IPackageService, PackageService>();
            return serviceCollection;
        }

        private static IServiceCollection MapConnectionStrings(this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));
            return serviceCollection;
        }
    }
}