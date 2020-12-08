// ***********************************************************************
// Assembly         : TimesheetLaikas
// Author           : Donatas & Matt
// Created          : 11-30-2020
//
// Last Modified By : Donatas & Matt
// Last Modified On : 12-07-2020
// ***********************************************************************
// <copyright file="Employee.cs" company="TimesheetLaikas">
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
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TimesheetLaikas.Models
{
    /// <summary>
    /// Class Employee.
    /// Implements the <see cref="Microsoft.AspNetCore.Identity.IdentityUser" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Identity.IdentityUser" />
    [Table("Employee", Schema = "College")]
    public class Employee : IdentityUser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> class.
        /// </summary>
        /// <remarks>The Id property is initialized to form a new GUID string value.</remarks>
        public Employee() : base()
        {
        }

        /// <summary>
        /// Gets or sets the emp fname.
        /// </summary>
        /// <value>The emp fname.</value>
        [PersonalData]
        [DisplayName("First Name")]
        public string EMP_FNAME { get; set; }

        /// <summary>
        /// Gets or sets the emp lname.
        /// </summary>
        /// <value>The emp lname.</value>
        [PersonalData]
        [DisplayName("Last Name")]
        public string EMP_LNAME { get; set; }

        /// <summary>
        /// Gets the full name.
        /// </summary>
        /// <value>The full name.</value>
        [NotMapped]
        [DisplayName("Full Name")]
        public string FULL_NAME => EMP_FNAME + " " + EMP_LNAME;

        //[PersonalData]
        //[DisplayName("Phone Number")]
        //public string EMP_PHONE { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        [PersonalData]
        [DisplayName("Address")]
        public string ADDRESS { get; set; }


        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        [PersonalData]
        [DisplayName("City")]
        public string CITY { get; set; }

        /// <summary>
        /// Gets or sets the zipcode.
        /// </summary>
        /// <value>The zipcode.</value>
        [PersonalData]
        [DisplayName("Zip Code")]
        public string ZIPCODE { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        [NotMapped]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the confirm password.
        /// </summary>
        /// <value>The confirm password.</value>
        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Gets or sets the payrate.
        /// </summary>
        /// <value>The payrate.</value>
        [DisplayName("Pay Rate")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal Payrate { get; set; }

        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>The department identifier.</value>
        [Required]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the department.
        /// </summary>
        /// <value>The department.</value>
        [ForeignKey(nameof(DepartmentId))]
        public Department Department { get; set; }

        /// <summary>
        /// Gets or sets the departments.
        /// </summary>
        /// <value>The departments.</value>
        [NotMapped]
        public List<SelectListItem> Departments { get; set; }

        //[DisplayName("Profile Picture")]
        //  public byte[] ProfilePic { get; set; }

        //public virtual ICollection<EmployeesInDepartment> EmployeesInDepartment { get; set; }
    }
  public class EmployeeContext : DbContext
        {
            private readonly string connectionString;

            public EmployeeContext(string connectionString)
            {
                this.connectionString = connectionString;
            }

            public DbSet<Employee> Employees { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.Equals(connectionString);
            }
        }
    }
}