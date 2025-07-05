using CoDzisNaObiad.Domain.Enums;

namespace CoDzisNaObiad.Application.Queries.GetRecipeByIngredients
{
    public class GetRecipeByIngredientsQuery
    {
        public string Ingredients { get; set; }
        public RecipeSources Sources { get; set; }
    }
}
