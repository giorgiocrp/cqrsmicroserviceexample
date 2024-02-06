using CatalogService.Commands;
using CatalogService.DataStore.Interfaces;
using CatalogService.Model;
using MediatR;

namespace CatalogService.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand,Product>
    {
        private readonly IWriteCatalogDataStore _dataStore;

        public AddProductHandler(IWriteCatalogDataStore dataStore) => _dataStore = dataStore;   

        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _dataStore.AddProduct(request.Product);

                return request.Product;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
