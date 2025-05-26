namespace CoDzisNaObiad.Infrastructure.ExternalApiClients.ModelsDto
{
    
    //Trochę dużo podobnych modeli, spróbuj to sobie uporządkować.
    // Idealnie potrzebujesz: 
    // 1) Modelu zwracanego z clienta (ale widzę, że on jest dostarczony razem a API)
    // 2) Modelu domenowego (takiego, który Twoja aplikacja rozumie)
    // 3) Modelu zwracanego z query (może być ten sam co powyżej)
    
    public class RecipeByIngredientsExternal
    {
        public int ProviderId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public List<IngredientInRecipeExternal> MissedIngredients { get; set; } = new();
        public List<IngredientInRecipeExternal> UsedIngredients { get; set; } = new();
    }
}
