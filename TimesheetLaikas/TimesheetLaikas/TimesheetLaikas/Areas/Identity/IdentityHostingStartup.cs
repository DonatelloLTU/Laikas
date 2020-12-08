// ***********************************************************************
// Assembly         : TimesheetLaikas
// Author           : Donatas & Matt
// Created          : 12-06-2020
//
// Last Modified By : Donatas & Matt
// Last Modified On : 12-07-2020
// ***********************************************************************
// <copyright file="IdentityHostingStartup.cs" company="TimesheetLaikas">
//     Copyright (c) HP Inc.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TimesheetLaikas.Data;
using TimesheetLaikas.Models;

[assembly: HostingStartup(typeof(TimesheetLaikas.Areas.Identity.IdentityHostingStartup))]
namespace TimesheetLaikas.Areas.Identity
{
    /// <summary>
    /// Class IdentityHostingStartup.
    /// Implements the <see cref="Microsoft.AspNetCore.Hosting.IHostingStartup" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Hosting.IHostingStartup" />
    public class IdentityHostingStartup : IHostingStartup
    {
        /// <summary>
        /// Configures the specified builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}
