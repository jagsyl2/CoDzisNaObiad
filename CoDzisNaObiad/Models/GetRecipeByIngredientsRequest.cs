using CoDzisNaObiad.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace CoDzisNaObiad.API.Models
{
    public class GetRecipeByIngredientsRequest
    {
        [FromRoute (Name ="ingredients")]
        public string Ingredients { get; set; }

        [FromQuery]
        public RecipeSources Source { get; set; }
    }
}