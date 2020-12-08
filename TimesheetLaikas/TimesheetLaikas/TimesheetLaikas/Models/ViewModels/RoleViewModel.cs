// ***********************************************************************
// Assembly         : TimesheetLaikas
// Author           : Donatas & Matt
// Created          : 11-30-2020
//
// Last Modified By : Donatas & Matt
// Last Modified On : 12-07-2020
// ***********************************************************************
// <copyright file="RoleViewModel.cs" company="TimesheetLaikas">
//     Copyright (c) HP Inc.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimesheetLaikas.Models.ViewModels
{
    /// <summary>
    /// Class RoleViewModel.
    /// </summary>
    public class RoleViewModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        /// <value>The name of the role.</value>
        [DisplayName("Role Name")]
        public string RoleName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

       // public PayPeriodTypes? PayPeriodDuration { get; set; }
    }

    /// <summary>
    /// Class RoleEmployeeList.
    /// </summary>
    public class RoleEmployeeList
    {
        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        /// <value>The role.</value>
        public Roles Role { get; set; }
        /// <summary>
        /// Gets or sets the employees with role.
        /// </summary>
        /// <value>The employees with role.</value>
        public IEnumerable<Employee> EmployeesWithRole { get; set; }
        // public IEnumerable<Employee> EmployeesNotWithRole { get; set; }
    }
}