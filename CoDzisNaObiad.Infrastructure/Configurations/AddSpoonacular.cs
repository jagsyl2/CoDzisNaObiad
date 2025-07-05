using CoDzisNaObiad.Infrastructure.ExternalApiClients.Spoonacular;
using CoDzisNaObiad.Infrastructure.ExternalApiClients.Spoonacular.Mappers;
using CoDzisNaObiad.Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CoDzisNaObiad.Infrastructure.Configurations
{
    public static class AddSpoonacular
    {
        public static IServiceCollection AddSpoonacularScope(
            this IServiceCollection services)
        {
            services.AddScoped<IExternalApiClient, SpoonacularApiClient>();
            services.AddScoped<ISpoonacularApiClient, SpoonacularApiClient>();
            services.AddScoped<ISpoonacularClient, SpoonacularClient>();
            services.AddScoped<IRecipeSpoonacularMapper, RecipeSpoonacularMapper>();

            return services;
        }
    }
}
