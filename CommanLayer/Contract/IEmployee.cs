using CommanLayer.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommanLayer.Contract
{
   public interface IEmployee
    {
        List<Employee> GetEmployees();
        Employee CreateEmployee(Employee employee);
        bool DeleteEmployee(int id);
        Employee GetEmployee(int id);
        Employee UpdateEmployee(Employee emp);

    }
}
