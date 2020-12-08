// ***********************************************************************
// Assembly         : TimesheetLaikas
// Author           : Donatas & Matt
// Created          : 11-30-2020
//
// Last Modified By : Donatas & Matt
// Last Modified On : 12-07-2020
// ***********************************************************************
// <copyright file="DivisionViewModel.cs" company="TimesheetLaikas">
//     Copyright (c) HP Inc.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimesheetLaikas.Models.ViewModels
{
    /// <summary>
    /// Class DivisionViewModel.
    /// </summary>
    public class DivisionViewModel
    {
        /// <summary>
        /// Gets or sets the name of the division.
        /// </summary>
        /// <value>The name of the division.</value>
        [Required]
        [DisplayName("Division Name")]
        public String DivisionName { get; set; }

        /// <summary>
        /// Gets or sets the divsion chair identifier.
        /// </summary>
        /// <value>The divsion chair identifier.</value>
        [DisplayName("Division Chair")]
        public String DivsionChairId { get; set; }

        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        /// <value>The employee.</value>
        [ForeignKey(nameof(DivsionChairId))]
        public Employee Employee { get; set; }

        //public virtual ICollection<DepartmentsInDivision> DepartmentsInDivision { get; set; }

        /// <summary>
        /// Gets or sets the departments.
        /// </summary>
        /// <value>The departments.</value>
        public virtual List<Department> Departments { get; set; }
    }
}