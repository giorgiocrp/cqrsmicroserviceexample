using CatalogService.Interfaces;

namespace CatalogService.Events {
    public class ProductAddedEvent: IDomainEvent
    {
        public int ProductId { get; init; }
        public DateTime DataEvento{get;set;}
    }
}