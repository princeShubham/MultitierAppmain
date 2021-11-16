using CommanLayer.models;
using System;
using System.Collections.Generic;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class EmployeeOperation:DbConfig
    {
        public List<Employee> GetEmployees()
        {
            SqlCommand command = new SqlCommand("sp_get_employees",base.connection);
            command.CommandType = CommandType.StoredProcedure;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlDataReader dr = command.ExecuteReader();
            List<Employee> emps = new List<Employee>();
            while (dr.Read())
            {
                Employee em = new Employee();
                em.Id =(int)dr["id"];
                em.Name = dr["name"].ToString();
                em.Email = dr["email"].ToString();
                em.Salary =(decimal)dr["salary"];
                emps.Add(em);
            }
            connection.Close();
            return emps;

            
        }
        public Employee CreateEmployee(Employee employee)
        {
            SqlCommand cmd = new SqlCommand("sp_insert_employee", base.connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", employee.Name);
            cmd.Parameters.AddWithValue("@email", employee.Email);
            cmd.Parameters.AddWithValue("@salary", employee.Salary);
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            int r =(int)cmd.ExecuteScalar();
            connection.Close();
            if (r == 1)
                return employee;
            else
                return null;
        }
        public bool DeleteEmployee(int id)
        {
            SqlCommand command = new SqlCommand("sp_delete_employee", base.connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
             int i =(int)command.ExecuteScalar();
            return Convert.ToBoolean(i);
        }

        public Employee GetEmployee(int id)
        {
            SqlCommand command = new SqlCommand("sp_get_employee_byid", base.connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlDataReader dr = command.ExecuteReader();
            dr.Read();
            Employee emp = new Employee();
            emp.Id = (int)dr["id"];
            emp.Name = dr["name"].ToString();
            emp.Email = dr["email"].ToString();
            emp.Salary = (decimal)dr["salary"];
            connection.Close();
            return emp;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            SqlCommand cmd = new SqlCommand("sp_update_employee", base.connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", employee.Id);   cmd.Parameters.AddWithValue("@name", employee.Name);
            cmd.Parameters.AddWithValue("@email", employee.Email);
            cmd.Parameters.AddWithValue("@salary", employee.Salary);
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            int r = (int)cmd.ExecuteScalar();
            connection.Close();
            if (r == 1)
                return employee;
            else
                return null;
        }
    }
}
