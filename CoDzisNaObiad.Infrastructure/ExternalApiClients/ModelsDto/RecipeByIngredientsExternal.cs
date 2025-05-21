namespace CoDzisNaObiad.Infrastructure.ExternalApiClients.ModelsDto
{
    public class RecipeByIngredientsExternal
    {
        public int ProviderId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public List<IngredientInRecipeExternal> MissedIngredients { get; set; } = new();
        public List<IngredientInRecipeExternal> UsedIngredients { get; set; } = new();
    }
}
