using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tarea.Models;

namespace Tarea.Services
{
    class CustomerSC: BaseSC
    {

        public IQueryable<Customer> GetAllCustomer()
        {
            return northwindContext.Customers.Select(s => s);
        }

        public Customer GetCustomerById(string customerId)
        {
            return GetAllCustomer().Where(c => c.CustomerId == customerId).FirstOrDefault();
        }

        public void AddCustomer(Customer newCustomer)
        {
            northwindContext.Customers.Add(newCustomer);
        }

    }
}
