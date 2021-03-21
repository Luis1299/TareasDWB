using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tarea.Models;

namespace Tarea.Services
{
    class OrderSC: BaseSC
    {
        public IQueryable<Order> GetAllOrders()
        {
            return northwindContext.Orders.Select(s => s);
        }

        public Order GetOrderById(int id)
        {
            return GetAllOrders().Where(o => o.OrderId == id).FirstOrDefault();
        }

        public void AddOrder(Order newOrder)
        {
            northwindContext.Orders.Add(newOrder);
            northwindContext.SaveChanges();
        }
    }
}
