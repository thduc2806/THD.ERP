using MediatR;
using System.Data;
using System.Data.SqlClient;
using THD.ERP.App;
using THD.ERP.Infrastructure.Repositories;
using THD.ERP.Infrastructure.Repositories.Students;

namespace THD.ERP.DI
{
    public static class BussinessDependenceInjection
    {
        public static void AddMediatorLayer(this IServiceCollection services)
        {
            services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(AssemblyMarker).Assembly));
        }

        public static void AddBuissinessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IStudentRepository), typeof(StudentRepository));
            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            services.AddTransient<IDbConnection>(sp => new SqlConnection(configuration.GetConnectionString("HRMDb")));
        }

    }
}
