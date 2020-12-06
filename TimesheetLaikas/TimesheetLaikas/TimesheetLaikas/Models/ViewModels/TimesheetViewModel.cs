using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimesheetLaikas.Models.ViewModels
{
    public class TimesheetViewModel
    {
        public string EmpID { get; set; }

        [ForeignKey(nameof(EmpID))]
        public Employee Employee { get; set; }

        public DateTime PunchIn { get; set; }
        public DateTime? PunchOut { get; set; }
        
        public string TotalWorkTime {get; set;}

        public decimal? TotalPay { get; set; }
    }
}