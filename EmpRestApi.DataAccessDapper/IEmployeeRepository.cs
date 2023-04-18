using System;
using EmpRestApi.Domain;

namespace EmpRestApi.DataAccessDapper
{
	public interface IEmployeeRepository
	{
        Task<IEnumerable<Employee>> GetAll();
        Task<IEnumerable<Employee>> GetEmpById(int Id);
        Task Add(Employee employee);
        Task Update(int Id , Employee employee);
        Task Delete(int Id);

    }
}

