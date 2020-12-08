// ***********************************************************************
// Assembly         : TimesheetLaikas
// Author           : Donatas & Matt
// Created          : 11-30-2020
//
// Last Modified By : Donatas & Matt
// Last Modified On : 12-07-2020
// ***********************************************************************
// <copyright file="Payperiod.cs" company="TimesheetLaikas">
//     Copyright (c) HP Inc.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimesheetLaikas.Models
{
    /// <summary>
    /// Class Payperiod.
    /// Implements the <see cref="TimesheetLaikas.Models.EntityBase" />
    /// </summary>
    /// <seealso cref="TimesheetLaikas.Models.EntityBase" />
    public class Payperiod : EntityBase
    {
        /// <summary>
        /// Gets or sets the time sheets for pay period.
        /// </summary>
        /// <value>The time sheets for pay period.</value>
        public List<Timesheet> TimeSheetsForPayPeriod { get; set; }

        /// <summary>
        /// Gets or sets the total hours worked.
        /// </summary>
        /// <value>The total hours worked.</value>
        public double TotalHoursWorked { get; set; }

        /// <summary>
        /// Gets or sets the over time worked.
        /// </summary>
        /// <value>The over time worked.</value>
        public double? OverTimeWorked { get; set; }

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
    }
}