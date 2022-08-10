using System;
using System.Collections.Generic;

namespace CorePrac.Models
{
    public partial class ReportingManager : BaseEntity
    {
        public ReportingManager()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
