using CoDzisNaObiad.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace CoDzisNaObiad.API.Models
{
    public class GetRecipeByIngredientsResponse
    {
        [FromRoute (Name ="ingredients")]
        public string Ingredients { get; set; }

        [FromQuery]
        public RecipeSources Sources { get; set; }
    }
}