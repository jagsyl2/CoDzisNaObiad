using CoDzisNaObiad.API.Models;
using FluentValidation;

namespace CoDzisNaObiad.API.Validators
{
    public class GetRecipeByIngredientResponseValidator : AbstractValidator<GetRecipeByIngredientsResponse>
    {
        public GetRecipeByIngredientResponseValidator()
        {
            RuleFor(x => x.Ingredients)
                .NotNull()
                .NotEmpty()
                .WithMessage("Ingredients can't be null or empty.");
        }
    }
}
