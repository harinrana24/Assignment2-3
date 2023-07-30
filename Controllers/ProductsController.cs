using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CoolCrafts.Models;
using System.Text.Json;

namespace CoolCrafts.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            //to Replace this logic with your actual data retrieval method
            var jsonFilePath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", "products.json");
            var jsonString = System.IO.File.ReadAllText(jsonFilePath);
            return JsonSerializer.Deserialize<List<Product>>(jsonString);
        }
    }
}
