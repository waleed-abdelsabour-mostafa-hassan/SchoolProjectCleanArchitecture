using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Services.Abstracts;
using SchoolProject.Services.Implementations;

namespace SchoolProject.Services
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentServices, StudentServices>();
            services.AddTransient<IDepartmentServices, DepartmentServices>();
            return services;
        }
    }
}
