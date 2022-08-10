using CorePrac.Entities;
using CorePrac.Models;

namespace CorePrac.Service.Employees
{
    public interface IEmployee
    {
        public IEnumerable<Employee> GetUsers();
        public Employee GetById(int Id);
      
    }
}
