using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tarea.Models;

namespace Tarea.Services
{
    class ProductSC: BaseSC
    {
        public Product GetProductById(int id)
        {
            return GetAllProducts().Where(p => p.ProductId == id).FirstOrDefault();
        }

        public IQueryable<Product> GetAllProducts()
        {
            return northwindContext.Products.Select(p => p);
        }

        public void AddProduct(Product newProduct)
        {
            northwindContext.Products.Add(newProduct);
            northwindContext.SaveChanges();
        }

        public void DeleteProductById(int id)
        {
            var product = GetProductById(id);
            northwindContext.Products.Remove(product);
            northwindContext.SaveChanges();
        }

    }
}
