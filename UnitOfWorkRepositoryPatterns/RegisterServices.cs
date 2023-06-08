using RespositoryLayer.Repository;
using RespositoryLayer.Repository.EmployeeRepository;
using RespositoryLayer.UnitOfWork;
using ServiceLayer.IServices;
using ServiceLayer.Services;

namespace UnitOfWorkRepositoryPatterns
{
    public static class RegisterServices
    {
        public static void RegisterConfigServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
