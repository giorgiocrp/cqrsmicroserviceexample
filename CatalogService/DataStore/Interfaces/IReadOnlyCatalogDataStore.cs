using CatalogService.Model;

namespace CatalogService.DataStore.Interfaces {
    public interface IReadOnlyCatalogDataStore{
        public Task<Product> GetProductById(int id);
        public Task<IEnumerable<Product>> GetProducts();
    }
}