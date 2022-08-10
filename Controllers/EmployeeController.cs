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

        [HttpPost]
        public IEnumerable<Employee> Get()
        {
            return _Employee.GetUsers();
        }

        
        [HttpPost]
        public Employee GetEmployee(int id)
        {
            return _Employee.GetById(id);
        }

        [HttpPost]
        public JsonResponseModel InsertUpdateEmployee(Employee value)
        {
            JsonResponseModel apiResponse = new JsonResponseModel();
            bool result = _Employee.InsertUpdate(value);

            if (result)
            {
                apiResponse.Status = ApiStatus.OK;
                apiResponse.Data = "Inserted";
                apiResponse.Message = "Ok";
            }
            else
            {
                apiResponse.Status = ApiStatus.Error;
                apiResponse.Data = null;
                apiResponse.Message = "Record already Exists!";
            }
            return apiResponse;
        }

        [HttpPost]
        public object GetAllEmployee()
        {
            return _Employee.GetEmployeeMaster();
        }

        [HttpPost]
        public object GetDepartmentList()
        {
            return _Employee.GetDepartmentList();
        }


        [HttpPost]
        public object GetReportingManagerList()
        {
            return _Employee.GetReportManagerList();
        }
    }
}
