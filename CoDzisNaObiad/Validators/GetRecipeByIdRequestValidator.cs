using CoDzisNaObiad.API.Models;
using FluentValidation;

namespace CoDzisNaObiad.API.Validators
{
    public class GetRecipeByIdRequestValidator : AbstractValidator<GetRecipeByIdRequest>
    {
        public GetRecipeByIdRequestValidator()
        {

            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Id should be grater than 0.");

            RuleFor(x => x.Sources)
                .NotNull()
                .WithMessage("Source should be chosen.");
        }
    }
}
