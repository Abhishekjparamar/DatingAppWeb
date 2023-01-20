using DatingApp.Data;
using DatingAppWeb.Interfaces;
using DatingAppWeb.Services;
using Microsoft.EntityFrameworkCore;

namespace DatingAppWeb.Extensions
{
    public static class ApplicationServicesExtention
    {
        public static IServiceCollection AddApplicationservices(this IServiceCollection Services, IConfiguration Configuration)
        {
            Services.AddDbContext<DataContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DedaultConn")));
            Services.AddCors();
            Services.AddScoped<ITokenRepository, TokenRepository>();
            Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return Services;
        }
    }
}
