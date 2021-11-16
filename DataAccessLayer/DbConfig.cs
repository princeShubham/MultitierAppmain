using System;
using System.Collections.Generic;
using System.Text;
using CommanLayer.models;
using Microsoft.Data.SqlClient;
namespace DataAccessLayer
{
    public class DbConfig
    {
        public SqlConnection connection;
        public DbConfig()
        {
            connection = new SqlConnection(ReadConnection.ConnectionString);
        }

    }
}
