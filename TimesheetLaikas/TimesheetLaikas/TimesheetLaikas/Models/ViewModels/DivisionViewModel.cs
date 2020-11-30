using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimesheetLaikas.Models.ViewModels
{
    public class DivisionViewModel
    {
        [Required]
        [DisplayName("Division Name")]
        public String DivisionName { get; set; }

        [DisplayName("Division Chair")]
        public String DivsionChairId { get; set; }

        [ForeignKey(nameof(DivsionChairId))]
        public Employee Employee { get; set; }

        //public virtual ICollection<DepartmentsInDivision> DepartmentsInDivision { get; set; }

        public virtual List<Department> Departments { get; set; }
    }
}