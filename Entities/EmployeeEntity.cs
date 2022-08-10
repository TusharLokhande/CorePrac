using CorePrac.Models;

namespace CorePrac.Entities
{
    public class EmployeeEntity: BaseEntity
    {
        public int Id { get; set; }
        public string? Ename { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? DepartmentId { get; set; }
        public int? ReportingManagerId { get; set; }
        public int? IsActive { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDateUtc { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDateUtc { get; set; }

        public string? DepartmentName { get; set; }
        public string? ReportingManagerName { get; set; }

        public virtual Department? Department { get; set; }
        public virtual ReportingManager? ReportingManager { get; set; }
    }
}
