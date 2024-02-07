using ExampleUi.Models;

namespace ExampleUi.Services.Interfaces
{
    public interface ICatalogService
    {
        Task<Product> GetProductById(int id);
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> AddProduct(Product entity);
    }
}