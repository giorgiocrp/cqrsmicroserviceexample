using CatalogService.Model;

namespace CatalogService.Services.Interfaces
{
    public interface ICatalogService
    {
        Task<Product> GetProductById(int id);
        Task<IEnumerable<Product>> GetProducts();
    }
}