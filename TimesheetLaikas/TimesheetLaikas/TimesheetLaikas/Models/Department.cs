using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace TimesheetLaikas.Models
{
    [Table("Department", Schema = "College")]
    public class Department : EntityBase
    {
        [Required]
        [DisplayName("Department Name")]
        [StringLength(50, MinimumLength = 3)]
        public String DeptName { get; set; }

        [Required]
        [DisplayName("Division")]
        public int DivisionId { get; set; }

        [ForeignKey(nameof(DivisionId))]
        public Division Division
        {
            get; set;
        }

        public virtual ICollection<Employee> Employees { get; set; }
    }

    public class Division : EntityBase
    {
        [Required]
        [DisplayName("Division Name")]
        public String DivisionName { get; set; }

        [DisplayName("Division Chair")]
        public String DivsionChairId { get; set; }

        [ForeignKey(nameof(DivsionChairId))]
        public Employee Employee { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
    }

    public class DepartmentsInDivision
    {
        public int DeptId { get; set; }

        [ForeignKey(nameof(DeptId))]
        public Department Department { get; set; }

        public string DivId { get; set; }

        [ForeignKey(nameof(DivId))]
        public Division Division { get; set; }
    }

    public class EmployeesInDepartment

    {
        public string EmpId { get; set; }

        [ForeignKey(nameof(EmpId))]
        public Employee Employee { get; set; }

        public int DeptId { get; set; }

        [ForeignKey(nameof(DeptId))]
        public Department Department { get; set; }
    }
}