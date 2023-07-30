using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using CoolCrafts.Models;

namespace CoolCrafts.Services
{
    public class JsonFileProductService
    {
        private readonly string _jsonFilePath;

        public JsonFileProductService(string jsonFilePath)
        {
            _jsonFilePath = jsonFilePath;
        }

        public IEnumerable<Product> GetProducts()
        {
            var jsonString = File.ReadAllText(_jsonFilePath);
            return JsonSerializer.Deserialize<IEnumerable<Product>>(jsonString);
        }
    }
}
