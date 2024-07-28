using MediatR;
using Microsoft.AspNetCore.Hosting;
using System.Reflection;
using THD.ERP.App;
using THD.ERP.App.Handlers.Authen;
using THD.ERP.Infrastructure.Repositories;
using THD.ERP.Infrastructure.Repositories.Departments;

namespace THD.ERP.DI
{
    public static class BussinessDependenceInjection
    {
        public static void AddMediatorLayer(this IServiceCollection services)
        {
            services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(AssemblyMarker).Assembly));
        }

        public static void AddBuissinessLayer(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
        }

    }
}
