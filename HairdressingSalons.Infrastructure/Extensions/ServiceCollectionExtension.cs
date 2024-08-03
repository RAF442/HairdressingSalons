using HairdressingSalons.Domain.Interfaces;
using HairdressingSalons.Infrastructure.Persistence;
using HairdressingSalons.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HairdressingSalons.Infrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<HairdressingSalonDbContext>(options => options.UseSqlServer(
            configuration.GetConnectionString("HairdressingSalons")));

        services.AddDefaultIdentity<IdentityUser>()
            .AddEntityFrameworkStores<HairdressingSalonDbContext>();

        services.AddScoped<IHairdressingSalonRepository, HairdressingSalonRepository>();
    }
}
