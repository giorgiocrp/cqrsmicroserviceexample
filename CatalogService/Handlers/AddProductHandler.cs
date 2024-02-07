using CatalogService.Commands;
using CatalogService.DataStore.Interfaces;
using CatalogService.Events;
using CatalogService.Model;
using MediatR;

namespace CatalogService.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand,Product>
    {
        private readonly IWriteCatalogDataStore _dataStore;
        private readonly IPublisher _publisher;

        public AddProductHandler(IWriteCatalogDataStore dataStore, IPublisher publisher) {
            _dataStore = dataStore;
            _publisher=publisher;
        }    

        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product=await _dataStore.AddProduct(request.Product);
                await SendProductAddedEvent(product,DateTime.Now);
                return product;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task SendProductAddedEvent(Product product, DateTime dataEvento)
        {
            await _publisher.Publish(new ProductAddedEvent(){ProductId=product.Id,DataEvento=dataEvento});
        }
    }
}
