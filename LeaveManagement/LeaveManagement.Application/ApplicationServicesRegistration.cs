using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LeaveManagement.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection ConfigurApplicationServices(this IServiceCollection service) 
        {
            service.AddAutoMapper(Assembly.GetExecutingAssembly());
            service.AddMediatR(Assembly.GetExecutingAssembly());

            return service;
        }
    }
}
