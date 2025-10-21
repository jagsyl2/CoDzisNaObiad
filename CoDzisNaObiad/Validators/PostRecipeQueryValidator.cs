using CoDzisNaObiad.Application.Queries.PostRecipe;
using FluentValidation;

namespace CoDzisNaObiad.API.Validators
{
    public class PostRecipeQueryValidator : AbstractValidator<PostRecipeQuery>
    {
        public PostRecipeQueryValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Name can't be null or empty.");

            RuleFor(x => x.Servings)
                .GreaterThan(0)
                .WithMessage("Servings should be grater than 0");

            RuleFor(x => x.ReadyInMinutes)
                .GreaterThan(0)
                .WithMessage("ReadyInMinutes should be grater than 0");

            RuleFor(x => x.CookingMinutes)
                .GreaterThan(0)
                .WithMessage("CookingMinutes should be grater than 0");

            RuleFor(x => x.PreparationMinutes)
                .GreaterThan(0)
                .WithMessage("PreparationMinutes should be grater than 0");

            RuleForEach(x => x.Ingredients)
                .SetValidator(new IngredientDtoValidator());
        }
    }
}
