// ***********************************************************************
// Assembly         : TimesheetLaikas
// Author           : Donatas & Matt
// Created          : 11-30-2020
//
// Last Modified By : Donatas & Matt
// Last Modified On : 12-07-2020
// ***********************************************************************
// <copyright file="DepartmentViewModel.cs" company="TimesheetLaikas">
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
    /// Class DepartmentViewModel.
    /// </summary>
    public class DepartmentViewModel
    {
        /// <summary>
        /// Gets or sets the name of the dept.
        /// </summary>
        /// <value>The name of the dept.</value>
        [Required]
        [DisplayName("Department Name")]
        [StringLength(50, MinimumLength = 3)]
        public String DeptName { get; set; }

        /// <summary>
        /// Gets or sets the division identifier.
        /// </summary>
        /// <value>The division identifier.</value>
        [Required]
        [DisplayName("Division")]
        public int DivisionId { get; set; }

        /// <summary>
        /// Gets or sets the division.
        /// </summary>
        /// <value>The division.</value>
        [ForeignKey(nameof(DivisionId))]
        public Division Division
        {
            get; set;
        }
    }
}