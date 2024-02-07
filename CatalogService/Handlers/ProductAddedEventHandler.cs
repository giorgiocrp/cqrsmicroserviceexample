using CatalogService.Commands;
using CatalogService.DataStore.Interfaces;
using CatalogService.Events;
using CatalogService.Model;
using MediatR;

namespace CatalogService.Handlers
{
    public class ProductAddedEventHandler : INotificationHandler<ProductAddedEvent>
    {        
        private readonly ILogger _logger;

        public ProductAddedEventHandler(ILogger<ProductAddedEventHandler> logger) {
            _logger=logger;
        }
        public async Task Handle(ProductAddedEvent notification, CancellationToken cancellationToken)
        {
            await Task.Run(()=>_logger.LogInformation($"inserito il prodotto con id: {notification.ProductId}"));            
        }
    }
}
