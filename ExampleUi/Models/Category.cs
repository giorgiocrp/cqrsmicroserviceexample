namespace ExampleUi.Models{
    public class Category{
          public int CategoryId { get; set; }

         public string Name {get;set;}
         public List<Product> ProductList {get;set;}
    }
}