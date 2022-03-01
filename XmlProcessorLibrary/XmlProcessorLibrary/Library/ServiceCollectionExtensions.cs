using Microsoft.Extensions.DependencyInjection;
using XmlProcessorLibrary.Repositories;

namespace XmlProcessorLibrary.Library
{
    public static class ServiceCollectionExtensions
    {
        public static void AddXmlProcessor(this IServiceCollection services) {

            services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
            services.AddSingleton<IEmployeeGenerator,EmployeeGenerator>();            
        }
    }
}
