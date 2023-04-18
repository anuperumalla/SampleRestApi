using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System;
using EmpRestApi.Domain;
using Microsoft.Extensions.Configuration;

namespace EmpRestApi.DataAccessDapper
{
    public class RepositoryBase 
    {
        protected readonly string connectionString;

        public RepositoryBase(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("EmployeeDB");
        }

        public Task AddEmployee(Employee employee)
        {
            throw new NotImplementedException();

        }

        public Task  DeleteEmployee(int Id)
        {
            throw new NotImplementedException();
        }

        

        public Task<Employee> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEmploye(Employee employee)
        {
            throw new NotImplementedException();
        }

        protected async Task<IEnumerable<T>> ExecuteAsync<T>(string query, object? param = null, CommandType? type = null)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                return await connection.QueryAsync<T>(query, param, commandType: type);
                
               
            }
        }

    }
}

