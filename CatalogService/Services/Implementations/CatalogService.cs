using CatalogService.DataStore.Interfaces;
using CatalogService.Model;
using CatalogService.Services.Interfaces;


namespace CatalogService.Services.Implementations
{
    public class CatalogService : ICatalogService
    {
        private readonly IConfiguration _configuration;
        private readonly IReadOnlyCatalogDataStore _readDataStore;
        private readonly IWriteCatalogDataStore _writeDataStore;

        public CatalogService(IConfiguration configuration, IReadOnlyCatalogDataStore readOnlyCatalogDataStore, IWriteCatalogDataStore writeCatalogDataStore) { 
            _configuration = configuration;
            _readDataStore = readOnlyCatalogDataStore;
            _writeDataStore = writeCatalogDataStore;
        }

        public async Task<Product> GetProductById(int id)
        {
           var result= await _readDataStore.GetProductById(id);
            return result;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var result= await _readDataStore.GetProducts();
            return result;
        }
    }
}