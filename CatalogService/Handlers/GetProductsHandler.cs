using CatalogService.Model;
using CatalogService.Queries;
using CatalogService.Services.Interfaces;
using MediatR;

namespace CatalogService.Handlers.Catalog
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private ICatalogService _catalogService;

        public GetProductsHandler(ICatalogService catalogService)
        {
            _catalogService=catalogService;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _catalogService.GetProducts();
        }
    }
}
