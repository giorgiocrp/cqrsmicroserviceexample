using System.Reflection.Metadata.Ecma335;
using CatalogService.DataStore.Interfaces;
using CatalogService.Model;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CatalogService.DataStore.Implementations
{
    public class WriteCatalogDataStore : IWriteCatalogDataStore
    {
        private readonly WriteDbContext _writeDbContext;
       

        //public WriteCatalogDataStore(WriteDbContext writeDbContext) {           
        //    _writeDbContext=writeDbContext;
        //}
        public async Task<Product> AddProduct(Product product)
        {
            var lista = new List<Product>();
            lista.Add(product);

            return await Task.Run(()=>product);
        }

       
    }


}