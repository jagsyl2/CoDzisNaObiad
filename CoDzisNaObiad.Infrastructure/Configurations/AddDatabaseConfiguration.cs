using CoDzisNaObiad.Infrastructure.Database.Mappers;
using CoDzisNaObiad.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CoDzisNaObiad.Infrastructure.Configurations
{
    public static class AddDatabaseConfiguration
    {
        public static IServiceCollection AddDatabaseConfigurationScope(this IServiceCollection services)
        {
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IRecipeMapper, RecipeMapper>();

            return services;
        }
    }
}
