using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimesheetLaikas.Models
{
    [Table("Timesheet", Schema = "Pay")]
    public class Timesheet : EntityBase
    {
        //public DateTime CurrentDate { get; set; }

        [DisplayName("Punch In")]
        public DateTime PunchIn { get; set; }

        [DisplayName("Punch Out")]
        public DateTime? PunchOut { get; set; }


        public string EmpID { get; set; }

        [ForeignKey(nameof(EmpID))]
        public Employee Employee { get; set; }


        [DisplayName("Total Hours Worked")]
        public string TotalWorkTime { get; set; }

        [DisplayName("Total Pay")]
        public decimal? TotalPay { get; set; }
    }

    public enum PayPeriodTypes
    {
        [Description("Weekly")]
        Weekly,

        [Description("BiWeekly")]
        Biweekly,

        [Description("Monthly")]
        Monthly,
    }
}