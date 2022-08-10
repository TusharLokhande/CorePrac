using CorePrac.Entities;
using CorePrac.Models;
using CorePrac.Service.Employees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace CorePrac.Controllers
{
    [Route("api/[controller]/{action=GetEmployee}/{id?}")]
    [ApiController]
    public class EmployeeController 
    {
        private readonly IEmployee _Employee;
        public EmployeeController(IEmployee employee)
        {
            this._Employee = employee;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _Employee.GetUsers();
        }

        
        [HttpGet]
       
        public Employee GetEmployee(int id)
        {
            return _Employee.GetById(id);
        }
    }
}
