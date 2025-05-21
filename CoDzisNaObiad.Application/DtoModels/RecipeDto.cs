namespace CoDzisNaObiad.Application.DtoModels
{
    public class RecipeDto
    {
        public int ProviderId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Servings { get; set; }
        public int ReadyInMinutes { get; set; }
        public int CookingMinutes { get; set; }
        public int PreparationMinutes { get; set; }
        public List<string> DishTypes { get; set; }
        public List<ExtendedIngredientDto> ExtendedIngredients { get; set; }
    }
}
