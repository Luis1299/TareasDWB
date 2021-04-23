using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tarea.Models;

namespace Tarea.Services
{
    class SupplierSC: BaseSC
    {
        public IQueryable<Supplier> GetAllSuppliers()
        {
            return northwindContext.Suppliers.Select(s => s);
        }

        public Supplier GetSupplierById(int id)
        {
            return GetAllSuppliers().Where(s => s.SupplierId == id).FirstOrDefault();
        }
    }
}
