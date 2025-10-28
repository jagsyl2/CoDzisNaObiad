using CoDzisNaObiad.API.Models;
using CoDzisNaObiad.Application.Queries.GetRecipeById;
using CoDzisNaObiad.Application.Queries.GetRecipeByIngredients;

namespace CoDzisNaObiad.API.Mappers
{
    public interface IRecipesMapper
    {
        GetRecipeByIdQuery GetRecipeByIdRequestToQuery(GetRecipeByIdRequest request);
        GetRecipeByIngredientsQuery GetRecipeByIngredientsRequestToQuery(GetRecipeByIngredientsRequest request);
    }

    public class RecipesMapper : IRecipesMapper
    {
        public GetRecipeByIdQuery GetRecipeByIdRequestToQuery(GetRecipeByIdRequest request)
        {
            return new GetRecipeByIdQuery()
            {
                Id = request.Id,
                SaveInDatabase = request.SaveInDatabase,
                Sources = request.Sources,
            };
        }

        public GetRecipeByIngredientsQuery GetRecipeByIngredientsRequestToQuery(GetRecipeByIngredientsRequest request)
        {
            return new GetRecipeByIngredientsQuery()
            {
                Ingredients = request.Ingredients,
                Source = request.Source
            };
        }
    }
}
