using CoDzisNaObiad.Application.Interfaces;
using CoDzisNaObiad.Domain.Models;
using CoDzisNaObiad.Infrastructure.Database.Repositories;
using CoDzisNaObiad.Infrastructure.Interfaces;

namespace CoDzisNaObiad.Application.Queries.GetRecipeById
{
    public class GetRecipeByIdHandler : IQueryHandler<GetRecipeByIdQuery, Recipe>
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IExternalApiClient _externalApiClient;

        public GetRecipeByIdHandler(
            IRecipeRepository recipeRepository,
            IExternalApiClient externalApiClient)
        {
            _recipeRepository = recipeRepository;
            _externalApiClient = externalApiClient;
        }

        public Recipe? Handle(GetRecipeByIdQuery query)
        {
            if (query.Sources == Domain.Enums.RecipeSources.Own)
            {
                return _recipeRepository.GetRecipeById(query.Id) ?? _recipeRepository.GetRecipeByProviderId(query.Id);
            }
            if (query.Sources == Domain.Enums.RecipeSources.Spoonacular)
            {
                if(_recipeRepository.CheckRecipeByProviderId(query.Id))
                {
                    return _recipeRepository.GetRecipeByProviderId(query.Id);
                }

                var recipe = _externalApiClient.GetRecipeById(query.Id);
                if (query.SaveInDatabase)
                {;
                    _recipeRepository.Add(recipe);
                }
                return recipe;
            }
            return null;
        }
    }
}
