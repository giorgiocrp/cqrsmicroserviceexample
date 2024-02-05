using CatalogService.Model;
using MediatR;

namespace CatalogService.Queries
{
    public record GetProductsQuery() : IRequest<IEnumerable<Product>>;
}
