using System;
using Dapper;
using EmpRestApi.Domain;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.Configuration;
using Mysqlx.Crud;
using static Dapper.SqlMapper;

namespace EmpRestApi.DataAccessDapper 
{
	public class EmployeeRepository :RepositoryBase, IEmployeeRepository

	{
        
       
        public EmployeeRepository(IConfiguration configuration) : base(configuration)
        {

            
        }

       public async Task<IEnumerable<Employee>> GetAll()
        {
            return await ExecuteAsync<Employee>("Select * from employee;");

        }

        public async Task<IEnumerable<Employee>> GetEmpById(int Id)
        {
            return await ExecuteAsync<Employee>("Select * from employee where EmployeeId = @Id;", new { Id = Id });
        }

        public async Task Add(Employee employee)
        {
            var query = "insert into employee(FirstName, LastName, Organisation, DateOfJoin) " +
                        "Values(@FirstName,@LastName, @Organisation, @DateOfJoin);";
            await ExecuteAsync<Employee>(query, employee);

        }

        public async Task  Update( Employee employee)
        {
            var query = "update employee set FirstName = @FirstName," +
                "LastName = @LastName, " +
                "Organisation = @Organisation," +
                "DateOfJoin = @DateOfJoin " +
                "where EmployeeId = @EmployeeId" +  ";";
             await ExecuteAsync<Employee>(query,  employee);
        }

        public async Task Delete(int Id)
        {
            var query = "Delete from Employee where EmployeeId=@Id;";
            await ExecuteAsync<Employee>(query, new {Id = Id});
        }


       
    }
}

