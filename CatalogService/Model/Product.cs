using CatalogService.Interfaces;

namespace CatalogService.Model
{
    public class Product:IBase
    {
         public int Id => ProductId;
         public int ProductId { get; set; }

         public string Name {get;set;}

         public virtual Category Category {get;set;}
    }
}