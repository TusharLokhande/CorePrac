using Microsoft.Data.SqlClient;
using System.Linq;
using CorePrac.Models;
using System.Data;
using CorePrac.Repository;
using CorePrac.Entities;
using Microsoft.EntityFrameworkCore;

namespace CorePrac.Service.Employees
{

    public class EmployeeService : IEmployee
    {

        private readonly IRepository<Employee> _repo;
        private readonly IndoContext _context;

        public EmployeeService(IndoContext  context, IRepository<Employee> repo)
        {
            this._context = context;
            _repo = repo;
        }

        public IEnumerable<Employee> GetUsers()
        {
            return _repo.GetAll();
        }

        public Employee GetById(int Id)
        {
            return _repo.GetById(Id);
        }

       
    }
}
