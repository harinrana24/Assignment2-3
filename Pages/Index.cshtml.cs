using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using CoolCrafts.Models; 
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace CoolCrafts.Pages
{
    public class IndexModel : PageModel
    {
        // this is to Property to hold the list of products
        public List<Product> Products { get; private set; }

        public void OnGet()
        {
            // this si to Replace this logic with your actual data retrieval method
            Products = GetProductsFromDatabase();
        }

        private List<Product> GetProductsFromDatabase()
        {
            // Replace the hardcoded sample data with code to read data from the JSON file
            var jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", "products.json");
            var jsonString = System.IO.File.ReadAllText(jsonFilePath);
            return JsonSerializer.Deserialize<List<Product>>(jsonString);
        }


    }

    public class Product
    {
        public string Id { get; set; }
        public string Maker { get; set; }
        public string img { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<int>? Ratings { get; set; }
    }
}
