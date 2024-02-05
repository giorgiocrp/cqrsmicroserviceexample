using ExampleUi.Models;
using ExampleUi.Services.Interfaces;
using ExampleUi.Utils.Implementations;

namespace ExampleUi.Services.Implementations
{
    public class CatalogService : ICatalogService
    {
        private readonly IConfiguration _configuration;
        public CatalogService(IConfiguration configuration) { 
            _configuration = configuration;
        }

        public async Task<Product> GetProductById(int id)
        {
            var client = new CatalogApiConsumer();
            var handler = new HttpClientHandler();
            client.BaseUrl = _configuration["ServiceEndPoint:ApiClient:CatalogServiceEndPoint"].ToString();
            var result = await client.GetAsync($"/gateway/catalog/product/getproduct/{id}", handler);
            return result;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var client = new CatalogApiConsumer();
            var handler = new HttpClientHandler();
            client.BaseUrl = _configuration["ServiceEndPoint:ApiClient:CatalogServiceEndPoint"].ToString();
            var result = await client.GetCollectionAsync($"/gateway/catalog/product/getproducts", handler);
            return result;
        }
    }
}