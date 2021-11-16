using CommanLayer.Contract;
using CommanLayer.models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class EmployeeBusiness : IEmployee
    {
      private EmployeeOperation context { get; }
        public EmployeeBusiness()
        {
            context = new EmployeeOperation();
        }
        
        public List<Employee> GetEmployees()
        {
            return context.GetEmployees();
        }
        
        public Employee CreateEmployee(Employee employee)
        {
            return context.CreateEmployee(employee);
        }

        public bool DeleteEmployee(int id)
        {
            var r = context.DeleteEmployee(id);
            return r;
        }

        public Employee GetEmployee(int id)
        {
            return context.GetEmployee(id);
        }

        public Employee UpdateEmployee(Employee emp)
        {
            return context.UpdateEmployee(emp);
        }
    }
}
