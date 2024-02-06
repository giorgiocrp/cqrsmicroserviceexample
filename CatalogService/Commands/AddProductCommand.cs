using CatalogService.Model;
using MediatR;

namespace CatalogService.Commands
{
    public record AddProductCommand(Product Product) : IRequest<Product>;
}
