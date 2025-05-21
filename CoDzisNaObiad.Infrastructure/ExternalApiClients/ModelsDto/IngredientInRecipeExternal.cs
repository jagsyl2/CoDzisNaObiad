namespace CoDzisNaObiad.Infrastructure.ExternalApiClients.ModelsDto
{
    public class IngredientInRecipeExternal
    {
        public int ProviderIngredientId {get; set;}
        public string Name { get; set;}
        public string ImageUrl { get; set;}
        public decimal Amount { get; set; }
        public string Unit { get; set; }
    }
}
