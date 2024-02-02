namespace ExampleUi.Models {
    public class Product{
          public int ProductId { get; set; }

         public string Name {get;set;}

         public virtual Category Category {get;set;}
    }
}