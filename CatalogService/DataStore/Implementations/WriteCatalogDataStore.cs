using CatalogService.DataStore.Interfaces;
using CatalogService.Model;

namespace CatalogService.DataStore.Implementations {
    public class WriteCatalogDataStore : IWriteCatalogDataStore
    {
        public async Task<Product> AddProduct(Product product)
        {
            var lista=new List<Product>();
            lista.Add(product);
            return product;
        }
    }
}