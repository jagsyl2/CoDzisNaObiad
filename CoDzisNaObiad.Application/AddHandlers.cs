using CoDzisNaObiad.Application.Interfaces;
using CoDzisNaObiad.Application.Queries.GetRecipeById;
using CoDzisNaObiad.Application.Queries.GetRecipeByIngredients;
using CoDzisNaObiad.Application.Queries.PostRecipe;
using CoDzisNaObiad.Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace CoDzisNaObiad.Application
{
    public static class AddHandlers
    {
        public static IServiceCollection AddHandlersConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IQueryHandler<GetRecipeByIngredientsQuery, List<RecipeByIngredients>>, GetRecipeByIngredientsHandler>();
            services.AddScoped<IQueryHandler<GetRecipeByIdQuery, Recipe>, GetRecipeByIdHandler>();
            services.AddScoped<IQueryHandler<PostRecipeQuery, int>, PostRecipeHandler>();

            return services;

        }
    }
}
