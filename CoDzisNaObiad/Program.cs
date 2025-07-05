using CoDzisNaObiad.Application;
using CoDzisNaObiad.Infrastructure.Configurations;
using CoDzisNaObiad.Infrastructure.Database;
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

            builder.Services.AddHandlersConfiguration();

            builder.Services.AddDatabaseConfigurationScope();
            builder.Services.AddDbContext<CoDzisNaObiadDbContext>();
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
