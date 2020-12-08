// ***********************************************************************
// Assembly         : TimesheetLaikas
// Author           : Donatas & Matt
// Created          : 11-30-2020
//
// Last Modified By : Donatas & Matt
// Last Modified On : 12-07-2020
// ***********************************************************************
// <copyright file="UserViewModel.cs" company="TimesheetLaikas">
//     Copyright (c) HP Inc.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    /// Class UserViewModel.
    /// </summary>
    public class UserViewModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //[DisplayName("Profile Picture")]
        //public byte[] ProfilePic { get; set; }

        /// <summary>
        /// Gets or sets the emp phone.
        /// </summary>
        /// <value>The emp phone.</value>
        [PersonalData]
        [DisplayName("Phone Number")]
        public String EMP_PHONE { get; set; }

        /// <summary>
        /// Gets or sets the confirm password.
        /// </summary>
        /// <value>The confirm password.</value>
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The new password and confirmation password do not match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

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
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        [PersonalData]
        [DisplayName("Address")]
        public string ADDRESS { get; set; }



        /// <summary>
        /// Gets or sets the states.
        /// </summary>
        /// <value>The states.</value>
        [NotMapped]
        public List<SelectListItem> States { get; set; }

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
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the application roles.
        /// </summary>
        /// <value>The application roles.</value>
        [NotMapped]
        public List<SelectListItem> ApplicationRoles { get; set; }

        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        /// <value>The role identifier.</value>
        [Display(Name = "Position")]
        public string RoleId { get; set; }

        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        /// <value>The roles.</value>
        [ForeignKey(nameof(RoleId))]
        public Roles Roles
        {
            get; set;
        }

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

        /// <summary>
        /// Gets or sets the payrate.
        /// </summary>
        /// <value>The payrate.</value>
        [DisplayName("Pay Rate")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal Payrate { get; set; }
    }
}