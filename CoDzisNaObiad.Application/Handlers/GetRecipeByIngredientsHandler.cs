using CoDzisNaObiad.Application.DtoModels;
using CoDzisNaObiad.Application.Interfaces;
using CoDzisNaObiad.Application.Mappers;
using CoDzisNaObiad.Application.Queries;
using CoDzisNaObiad.Infrastructure.Interfaces;

namespace CoDzisNaObiad.Application.Handlers
{
    public class GetRecipeByIngredientsHandler : IQueryHandler<GetRecipeByIngredientsQuery, List<RecipeByIngredientsDto>>
    {
        private readonly IExternalApiClient _externalApiClient;
        private readonly IRecipeMapper _recipeMapper;

        public GetRecipeByIngredientsHandler(
            IExternalApiClient externalApiClient,
            IRecipeMapper recipeMapper)
        {
            _externalApiClient = externalApiClient;
            _recipeMapper = recipeMapper;
        }

        public List<RecipeByIngredientsDto> Handle(GetRecipeByIngredientsQuery query)
        {

            var recipes = _externalApiClient.GetRecipesByIngredients(query.Ingredients);
            return _recipeMapper.MapRecipiesToRecipiesIngredients(recipes);
        }
    }
}
