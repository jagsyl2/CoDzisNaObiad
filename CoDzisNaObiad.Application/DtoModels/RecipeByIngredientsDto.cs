namespace CoDzisNaObiad.Application.DtoModels
{
    public class RecipeByIngredientsDto
    {
        public int ProviderId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public List<IngredientInRecipeDto> MissedIngredients { get; set; } = new();
        public List<IngredientInRecipeDto> UsedIngredients { get; set; } = new();
    }
}
