using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LeaveManagement.Application
{
    public static class ApplicationServicesRegistration
    {
        public static void ConfigurApplicationServices(this IServiceCollection service) 
        {
            service.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
