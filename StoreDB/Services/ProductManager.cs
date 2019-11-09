using StoreDB.Models;
using StoreDB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreDB.Services
{
    public class ProductManager : IDataRepository<Product>
    {
        StoreDB.DB.StoreDBContext _context;

        public ProductManager(StoreDB.DB.StoreDBContext context)
        {
            this._context = context;
        }

        public int Add(Product entity)
        {
            this._context.Add<Product>(entity);
            this._context.SaveChanges();
            return entity.ProductId;

        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public Product Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public void Update(Product dbEntity, Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
