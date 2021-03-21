using System;
using System.Linq;
using Tarea.Models;
using Tarea.Services;

namespace Tarea
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            NorthwindContext dbContext = new NorthwindContext();

            // SELECT * FROM Products
            var products = dbContext.Products.Select(p => p).ToList();

            foreach(var product in products)
            {
                // Imprimir en consola el Id y el nombre del producto
                Console.WriteLine(product.ProductId + " - "+ product.ProductName);
            }
            */

            var products = new ProductSC().GetAllProducts().ToList();

            foreach (var product in products)
            {
                // Imprimir en consola el Id y el nombre del producto
                Console.WriteLine(product.ProductId + " - " + product.ProductName);
            }

            Console.ReadLine();

        }
    }
}
