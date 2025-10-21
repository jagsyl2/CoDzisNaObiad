using CoDzisNaObiad.Application.Interfaces;
using CoDzisNaObiad.Domain.Models;
using CoDzisNaObiad.Infrastructure.Database.Repositories;
using CoDzisNaObiad.Infrastructure.Interfaces;

namespace CoDzisNaObiad.Application.Queries.GetRecipeByIngredients
{
    public class GetRecipeByIngredientsHandler : IQueryHandler<GetRecipeByIngredientsQuery, List<RecipeByIngredients>>
    {
        private readonly IExternalApiClient _externalApiClient;
        private readonly IRecipeRepository _recipeRepository;

        public GetRecipeByIngredientsHandler(
            IExternalApiClient externalApiClient,
            IRecipeRepository recipeRepository)
        {
            _externalApiClient = externalApiClient;
            _recipeRepository = recipeRepository;
        }

        public List<RecipeByIngredients>? Handle(GetRecipeByIngredientsQuery query)
        {
            if (query.Sources == Domain.Enums.RecipeSources.Spoonacular)
            {
                return _externalApiClient.GetRecipesByIngredients(query.Ingredients);
            }
            if (query.Sources == Domain.Enums.RecipeSources.Own)
            {
                return _recipeRepository.GetRecipesByIngredients(query.Ingredients);
            }
            return null;


        }
    }
}
