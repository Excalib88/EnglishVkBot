using EnglishVkBot.DataAccess.Abstractions;
using EnglishVkBot.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EnglishVkBot.DataAccess
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(builder =>
            {
                builder.EnableSensitiveDataLogging(true);

                builder.UseNpgsql(configuration.GetConnectionString("Db"),
                    x => x.MigrationsAssembly(
                            "EnglishVkBot.DataAccess")
                        .CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
            });
            services
                .AddScoped<IDbRepository, EFRepository>(provider =>
                    new EFRepository(provider.GetRequiredService<DataContext>()));
            return services;
        }
    }
}