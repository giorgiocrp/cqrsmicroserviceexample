using CatalogService.Model;
using CatalogService.Queries;
using CatalogService.Services.Interfaces;
using MediatR;

namespace CatalogService.Handlers.Catalog
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private ICatalogService _catalogService;

        public GetProductByIdHandler(ICatalogService catalogService)
        {
            _catalogService=catalogService;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _catalogService.GetProductById(request.Id);
        }
    }
}
