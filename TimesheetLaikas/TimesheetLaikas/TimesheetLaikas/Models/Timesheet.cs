// ***********************************************************************
// Assembly         : TimesheetLaikas
// Author           : Donatas & Matt
// Created          : 11-30-2020
//
// Last Modified By : Donatas & Matt
// Last Modified On : 12-07-2020
// ***********************************************************************
// <copyright file="Timesheet.cs" company="TimesheetLaikas">
//     Copyright (c) HP Inc.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
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
    /// <summary>
    /// Class Timesheet.
    /// Implements the <see cref="TimesheetLaikas.Models.EntityBase" />
    /// </summary>
    /// <seealso cref="TimesheetLaikas.Models.EntityBase" />
    [Table("Timesheet", Schema = "Pay")]
    public class Timesheet : EntityBase
    {
        //public DateTime CurrentDate { get; set; }

        /// <summary>
        /// Gets or sets the punch in.
        /// </summary>
        /// <value>The punch in.</value>
        [DisplayName("Punch In")]
        public DateTime PunchIn { get; set; }

        /// <summary>
        /// Gets or sets the punch out.
        /// </summary>
        /// <value>The punch out.</value>
        [DisplayName("Punch Out")]
        public DateTime? PunchOut { get; set; }


        /// <summary>
        /// Gets or sets the emp identifier.
        /// </summary>
        /// <value>The emp identifier.</value>
        public string EmpID { get; set; }

        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        /// <value>The employee.</value>
        [ForeignKey(nameof(EmpID))]
        public Employee Employee { get; set; }
        /// <summary>
        /// Gets or sets the statuses.
        /// </summary>
        /// <value>The statuses.</value>
        [NotMapped]
        public List<SelectListItem> Statuses { get; set; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [DisplayName("Status")]
        public StatusTypes Status { get; set; }

        /// <summary>
        /// Gets or sets the total work time.
        /// </summary>
        /// <value>The total work time.</value>
        [DisplayName("Total Hours Worked")]
        public string TotalWorkTime { get; set; }

        /// <summary>
        /// Gets or sets the total pay.
        /// </summary>
        /// <value>The total pay.</value>
        [DisplayName("Total Pay")]
        public decimal? TotalPay { get; set; }
    }

    /// <summary>
    /// Enum StatusTypes
    /// </summary>
    public enum StatusTypes
    {

        /// <summary>
        /// The pending
        /// </summary>
        [Description("Pending")]
        Pending,
        /// <summary>
        /// The approved
        /// </summary>
        [Description("Approved")]
        Approved,
        /// <summary>
        /// The rejected
        /// </summary>
        [Description("Rejected")]
        Rejected
    }
}