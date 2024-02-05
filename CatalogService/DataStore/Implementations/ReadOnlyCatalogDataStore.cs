using CatalogService.DataStore.Interfaces;
using CatalogService.Model;

namespace CatalogService.DataStore.Implementations {
    public class ReadOnlyCatalogDataStore : IReadOnlyCatalogDataStore
    {
        public async Task<Product> GetProductById(int id)
        {
            return await Task.Run(() => new Product(){ ProductId=id, Name="Prodotto test", Category=new Category() { CategoryId=1, Name="Categoria Test"}});
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await Task.Run(() => new List<Product>(){ 
                new Product(){ProductId=1, Name="Prodotto test 1", Category=new Category() { CategoryId=1, Name="Categoria Test"}},
                new Product(){ProductId=2, Name="Prodotto test 2", Category=new Category() { CategoryId=1, Name="Categoria Test"}}}                
            );
        }
    }
}