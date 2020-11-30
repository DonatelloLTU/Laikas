using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimesheetLaikas.Models
{
    public class Payperiod : EntityBase
    {
        public List<Timesheet> TimeSheetsForPayPeriod { get; set; }

        public double TotalHoursWorked { get; set; }

        public double? OverTimeWorked { get; set; }

        public string EmpID { get; set; }

        [ForeignKey(nameof(EmpID))]
        public Employee Employee { get; set; }
    }
}