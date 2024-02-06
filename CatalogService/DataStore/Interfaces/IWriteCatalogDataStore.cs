using CatalogService.Model;

namespace CatalogService.DataStore.Interfaces {
    public interface IWriteCatalogDataStore
    {
        Task<Product> AddProduct(Product product);
    }
}