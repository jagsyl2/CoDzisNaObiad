using CoDzisNaObiad.API.Models;
using CoDzisNaObiad.Application.Queries.GetRecipeById;
using CoDzisNaObiad.Application.Queries.GetRecipeByIngredients;

namespace CoDzisNaObiad.API.Mappers
{
    public interface IRecipesMapper
    {
        GetRecipeByIdQuery GetRecipeByIdResponseToQuery(GetRecipeByIdResponse response);
        GetRecipeByIngredientsQuery GetRecipeByIngredientsResponseToQuery(GetRecipeByIngredientsResponse response);
    }

    public class RecipesMapper : IRecipesMapper
    {
        public GetRecipeByIdQuery GetRecipeByIdResponseToQuery(GetRecipeByIdResponse response)
        {
            return new GetRecipeByIdQuery()
            {
                Id = response.Id,
                SaveInDatabase = response.SaveInDatabase,
                Sources = response.Sources,
            };
        }

        public GetRecipeByIngredientsQuery GetRecipeByIngredientsResponseToQuery(GetRecipeByIngredientsResponse request)
        {
            return new GetRecipeByIngredientsQuery()
            {
                Ingredients = request.Ingredients,
                Sources = request.Sources
            };
        }
    }
}
