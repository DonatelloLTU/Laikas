// ***********************************************************************
// Assembly         : TimesheetLaikas
// Author           : Donatas & Matt
// Created          : 11-30-2020
//
// Last Modified By : Donatas & Matt
// Last Modified On : 12-07-2020
// ***********************************************************************
// <copyright file="Department.cs" company="TimesheetLaikas">
//     Copyright (c) HP Inc.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace TimesheetLaikas.Models
{
    /// <summary>
    /// Class Department.
    /// Implements the <see cref="TimesheetLaikas.Models.EntityBase" />
    /// </summary>
    /// <seealso cref="TimesheetLaikas.Models.EntityBase" />
    [Table("Department", Schema = "College")]
    public class Department : EntityBase
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

        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        /// <value>The employee.</value>
        public virtual ICollection<Employee> Employee { get; set; }
    }

    /// <summary>
    /// Class Division.
    /// Implements the <see cref="TimesheetLaikas.Models.EntityBase" />
    /// </summary>
    /// <seealso cref="TimesheetLaikas.Models.EntityBase" />
    public class Division : EntityBase
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

        /// <summary>
        /// Gets or sets the departments.
        /// </summary>
        /// <value>The departments.</value>
        public virtual ICollection<Department> Departments { get; set; }
    }

    /// <summary>
    /// Class DepartmentsInDivision.
    /// </summary>
    public class DepartmentsInDivision
    {
        /// <summary>
        /// Gets or sets the dept identifier.
        /// </summary>
        /// <value>The dept identifier.</value>
        public int DeptId { get; set; }

        /// <summary>
        /// Gets or sets the department.
        /// </summary>
        /// <value>The department.</value>
        [ForeignKey(nameof(DeptId))]
        public Department Department { get; set; }

        /// <summary>
        /// Gets or sets the div identifier.
        /// </summary>
        /// <value>The div identifier.</value>
        public string DivId { get; set; }

        /// <summary>
        /// Gets or sets the division.
        /// </summary>
        /// <value>The division.</value>
        [ForeignKey(nameof(DivId))]
        public Division Division { get; set; }
    }

    /// <summary>
    /// Class EmployeesInDepartment.
    /// </summary>
    public class EmployeesInDepartment

    {
        /// <summary>
        /// Gets or sets the emp identifier.
        /// </summary>
        /// <value>The emp identifier.</value>
        public string EmpId { get; set; }

        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        /// <value>The employee.</value>
        [ForeignKey(nameof(EmpId))]
        public Employee Employee { get; set; }

        /// <summary>
        /// Gets or sets the dept identifier.
        /// </summary>
        /// <value>The dept identifier.</value>
        public int DeptId { get; set; }

        /// <summary>
        /// Gets or sets the department.
        /// </summary>
        /// <value>The department.</value>
        [ForeignKey(nameof(DeptId))]
        public Department Department { get; set; }
    }
}