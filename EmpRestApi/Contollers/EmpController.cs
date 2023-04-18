using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpRestApi.DataAccessDapper;
using EmpRestApi.Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmpRestApi.Contollers
{
    [Route("api/Employee")]
    [ApiController]
    public class EmpController : Controller
    {
        private IEmployeeRepository _irepositoryBase;

        public EmpController(DataAccessDapper.IEmployeeRepository irepositoryBase)
        {
            _irepositoryBase = irepositoryBase;
            
        }

        // GET: /<controller>/
        [HttpGet("Employees")]
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _irepositoryBase.GetAll();
        }

        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            await _irepositoryBase.Add(employee);
            return Ok(new { message = "New Employee created" });
        }

        [HttpGet("ById")]
        public async Task<IEnumerable<Employee>> GetEmployeeByIdAsync(int id)
        {
            return await _irepositoryBase.GetEmpById(id );
        }
       
        [HttpPut("Id")]
        public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
        {
            var emp = await _irepositoryBase.GetEmpById(id);
            if (emp == null)
                throw new KeyNotFoundException("User not found");
            else
                await _irepositoryBase.Update(id, employee);
                return Ok(new { message = "Given Id Employee details updated" });
        }

        [HttpDelete("Id")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _irepositoryBase.Delete(id);
            return Ok(new { message = "Given Id emplpyee details deleted" });
        }

    }
}

