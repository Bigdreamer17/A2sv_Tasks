using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace CleanArch_Blog.src.Core.Blog.Application
{
    public static class ApplicationServiceRegistration {
        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

        }
    }
}
