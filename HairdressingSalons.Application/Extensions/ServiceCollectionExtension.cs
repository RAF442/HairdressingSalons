using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using HairdressingSalons.Application.ApplicationUser;
using HairdressingSalons.Application.Commands.CreateHairdressingSalon;
using HairdressingSalons.Application.Mappings;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace HairdressingSalons.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IUserContext, UserContext>();
        services.AddMediatR(typeof(CreateHairdressingSalonCommand));

        services.AddScoped(provider => new MapperConfiguration(cfg =>
        {
            var scope = provider.CreateScope();
            var userContext = scope.ServiceProvider.GetRequiredService<IUserContext>();
            cfg.AddProfile(new HairdressingSalonMappingProfile(userContext));
        }).CreateMapper()
        );

        services.AddValidatorsFromAssemblyContaining<CreateHairdressingSalonCommandValidator>()
            .AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters();
    }
}
