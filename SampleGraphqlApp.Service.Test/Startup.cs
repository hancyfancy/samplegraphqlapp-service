using Microsoft.Extensions.DependencyInjection;
using SampleGraphqlApp.Data.Interface.Repositories;
using SampleGraphqlApp.Data.Repositories;
using SampleGraphqlApp.Service.Interface.Services;
using SampleGraphqlApp.Service.Services;

namespace SampleGraphqlApp.Service.Test
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IStudentService, StudentService>();
        }
    }
}
