// ***********************************************************************
// Assembly         : TimesheetLaikas
// Author           : Donatas & Matt
// Created          : 11-30-2020
//
// Last Modified By : Donatas & Matt
// Last Modified On : 12-07-2020
// ***********************************************************************
// <copyright file="Roles.cs" company="TimesheetLaikas">
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

namespace TimesheetLaikas.Models
{
    /// <summary>
    /// Class Roles.
    /// Implements the <see cref="Microsoft.AspNetCore.Identity.IdentityRole" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Identity.IdentityRole" />
    [Table("Roles", Schema = "College")]
    public class Roles : IdentityRole
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Roles"/> class.
        /// </summary>
        /// <remarks>The Id property is initialized to form a new GUID string value.</remarks>
        public Roles() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Roles"/> class.
        /// </summary>
        /// <param name="roleName">The role name.</param>
        /// <remarks>The Id property is initialized to form a new GUID string value.</remarks>
        public Roles(string roleName) : base(roleName)
        {
        }

       // public PayPeriodTypes? PayPeriodDuration { get; set; }
    }
}