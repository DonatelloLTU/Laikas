using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimesheetLaikas.Models.ViewModels
{
    public class DepartmentViewModel
    {
        [Required]
        [DisplayName("Department Name")]
        [StringLength(50, MinimumLength = 3)]
        public String DeptName { get; set; }

        

        
    }
}
