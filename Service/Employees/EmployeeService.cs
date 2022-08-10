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
        private readonly IRepository<Department> _Dep;
        private readonly IRepository<ReportingManager> _RM;
        private readonly IndoContext _context;

        public EmployeeService(IndoContext  context, IRepository<Employee> repo, IRepository<Department> Dep, IRepository<ReportingManager> RM)
        {
            this._context = context;
            _repo = repo;
            _Dep = Dep;
            _RM = RM;   
        }

        public IEnumerable<Employee> GetUsers()
        {
            return _repo.GetAll();
        }

        public Employee GetById(int Id)
        {
            return _repo.GetById(Id);
        }

        public dynamic InsertUpdate(Employee value)
        {
          
            //Insert
            if(value.Id == 0)
            {
                bool checkDuplicate1 = _repo.Table.Any(x => x.Id == value.Id);
                if (checkDuplicate1) return false;
                _repo.Insert(value);
                return true;
            }

            //update
            bool checkDuplicate = _repo.Table.Any(x => x.Id != value.Id);
            if(!checkDuplicate) return false;
            _repo.Update(value);
            return true;
        }


        public dynamic GetEmployeeMaster()
        {
            var data = (
                 from em in _repo.Table
                 join cc in _Dep.Table on em.DepartmentId equals cc.Id
                 join rr in _RM.Table on  em.ReportingManagerId  equals rr.Id
                 select new
                 {
                   Id = em.Id,
                   Name = em.Ename,
                   Email = em.Email,
                   DateOfBirth = em.DateOfBirth,
                   DepartmentName = cc.Name,
                   ReportingManagerName = rr.Name
                 }
                );

            return data;
        }

        public dynamic GetDepartmentList()
        {
            var data = (from cc in _Dep.Table select new { Id = cc.Id, Name = cc.Name });
            return data;
        }
        public dynamic GetReportManagerList()
        {
            var data = (from cc in _RM.Table select new { Id = cc.Id, Name = cc.Name });
            return data;
        }
        
    }
}
