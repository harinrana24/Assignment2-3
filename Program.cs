using CoolCrafts.Services; 
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CoolCrafts
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adding the service
            builder.Services.AddSingleton<JsonFileProductService>(serviceProvider =>
            {
                var jsonFilePath = System.IO.Path.Combine(builder.Environment.ContentRootPath, "wwwroot", "data", "products.json");
                return new JsonFileProductService(jsonFilePath);
            });

            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
