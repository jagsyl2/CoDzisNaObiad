using CoDzisNaObiad.Application.Enums;

namespace CoDzisNaObiad.Application.Queries.GetRecipeByIngredients
{
    
    //Wrzucaj query i handlery obok siebie, łatwiej jest po nich nawigować
    // tutaj zrobiłem zmianę, żeby pokazać przykład
    
    
    
    public class GetRecipeByIngredientsQuery
    {
        public string Ingredients { get; set; }
        public Zasoby Zasoby { get; set; }
    }
}
