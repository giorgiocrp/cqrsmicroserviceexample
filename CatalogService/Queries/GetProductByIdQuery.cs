using CatalogService.Model;
using MediatR;

namespace CatalogService.Queries
{
    public record GetProductByIdQuery(int Id) : IRequest<Product>;
}
