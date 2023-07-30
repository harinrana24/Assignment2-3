using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Text.Json;

public class ProductsModel : PageModel
{
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

    public List<Product> Products { get; private set; }

    public void OnGet()
    {
        // Read the products.json file from wwwroot
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "products.json");
        var json = System.IO.File.ReadAllText(filePath);

        // Deserialize the JSON data into a list of Product objects
        Products = JsonSerializer.Deserialize<List<Product>>(json);
    }
}
