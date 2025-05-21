using CoDzisNaObiad.Application.DtoModels;
using CoDzisNaObiad.Application.Handlers;
using CoDzisNaObiad.Application.Interfaces;
using CoDzisNaObiad.Application.Mappers;
using CoDzisNaObiad.Application.Queries;
using CoDzisNaObiad.Infrastructure;
using CoDzisNaObiad.Infrastructure.ExternalApiClients.Spoonacular;
using spoonacular.Api;
using System.Text.Json.Serialization;

namespace CoDzisNaObiad.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.Configure<SpoonacularConfig>(
                builder.Configuration.GetSection("ApiConfigurations:SpoonacularConfig"));
            builder.Services.AddSpoonacularScope();

            builder.Services.AddScoped<RecipesApi>(provider =>
            {
                var spoonacularConfig = provider.GetService<ISpoonacularClient>();
                return spoonacularConfig.CreateRecipesSpoonacularClient();
            });

            builder.Services.AddScoped<IRecipeMapper, RecipeMapper>();
            builder.Services.AddScoped<IQueryHandler<GetRecipeByIngredientsQuery, List<RecipeByIngredientsDto>>, GetRecipeByIngredientsHandler>();

            builder.Services
                .AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
