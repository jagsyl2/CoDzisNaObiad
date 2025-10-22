using CoDzisNaObiad.API.Mappers;
using CoDzisNaObiad.API.Validators;
using CoDzisNaObiad.Application;
using CoDzisNaObiad.Infrastructure.Configurations;
using CoDzisNaObiad.Infrastructure.Database;
using CoDzisNaObiad.Infrastructure.ExternalApiClients.Spoonacular;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
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

            builder.Services.AddHandlersConfiguration();

            builder.Services.AddDatabaseConfigurationScope();
            builder.Services.AddDbContext<CoDzisNaObiadDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
            });
            builder.Services
                .AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssemblyContaining<GetRecipeByIdRequestValidator>();
            builder.Services.AddScoped<IRecipesMapper, RecipesMapper>();

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
