using CorePrac.Entities;
using CorePrac.Models;

namespace CorePrac.Service.Employees
{
    public interface IEmployee
    {
        public IEnumerable<Employee> GetUsers();
        public Employee GetById(int Id);

        public dynamic InsertUpdate(Employee emp);

        public dynamic GetEmployeeMaster();

        public dynamic GetDepartmentList();

        public dynamic GetReportManagerList();
    }
        
}
