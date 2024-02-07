using CatalogService.Interfaces;

namespace CatalogService.Model
{
    public class Category:Entity,IBase
    {
         public int Id => CategoryId;
         public int CategoryId { get; set; }

         public string Name {get;set;}
         public List<Product> ProductList {get;set;}
    }
}