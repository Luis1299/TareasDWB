﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tarea.Models;

namespace Tarea.Services
{
    public class EmployeeSC : BaseSC
    {
        public Employee GetEmployeeById(int id)
        {
            return GetAllEmployees().Where(w => w.EmployeeId == id).FirstOrDefault();
        }

        public IQueryable<Employee> GetAllEmployees()
        {
            return northwindContext.Employees.Select(s => s);
        }

        public void DeleteEmployeeById(int id)
        {
            var employee = GetEmployeeById(id);
            northwindContext.Employees.Remove(employee);
            northwindContext.SaveChanges();
        }

        public void UpdateEmployeeFirstNameById(int id, string newName)
        {
            Employee currentEmployee = GetEmployeeById(id);

            if (currentEmployee == null)
                throw new Exception("No se encontró el empleado con el ID proporcionado");

            currentEmployee.FirstName = newName;
            northwindContext.SaveChanges();
        }

        public void AddEmployee(Employee newEmployee)
        {
            var newEmployeeRegister = new Employee()
            {
                FirstName = newEmployee.FirstName,
                LastName = newEmployee.LastName,
                BirthDate = newEmployee.BirthDate,
                Address = newEmployee.Address,
                Country = newEmployee.Country
            };


            northwindContext.Add(newEmployeeRegister);
            northwindContext.SaveChanges();
        }

    }
}
