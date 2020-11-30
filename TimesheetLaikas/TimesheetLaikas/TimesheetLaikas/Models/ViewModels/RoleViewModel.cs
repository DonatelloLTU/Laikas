using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimesheetLaikas.Models.ViewModels
{
    public class RoleViewModel
    {
        public string Id { get; set; }

        [DisplayName("Role Name")]
        public string RoleName { get; set; }

        public string Description { get; set; }

        public PayPeriodTypes? PayPeriodDuration { get; set; }
    }

    public class RoleEmployeeList
    {
        public Roles Role { get; set; }
        public IEnumerable<Employee> EmployeesWithRole { get; set; }
        // public IEnumerable<Employee> EmployeesNotWithRole { get; set; }
    }
}