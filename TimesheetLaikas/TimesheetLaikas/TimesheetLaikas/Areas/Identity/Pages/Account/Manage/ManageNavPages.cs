// ***********************************************************************
// Assembly         : TimesheetLaikas
// Author           : Donatas & Matt
// Created          : 12-06-2020
//
// Last Modified By : Donatas & Matt
// Last Modified On : 12-07-2020
// ***********************************************************************
// <copyright file="ManageNavPages.cs" company="TimesheetLaikas">
//     Copyright (c) HP Inc.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using TimesheetLaikas.Models;

namespace TimesheetLaikas.Areas.Identity.Pages.Account.Manage
{
    /// <summary>
    /// Class ManageNavPages.
    /// </summary>
    public static class ManageNavPages
    {
        /// <summary>
        /// Gets the index.
        /// </summary>
        /// <value>The index.</value>
        public static string Index => "Index";

        /// <summary>
        /// Gets the change password.
        /// </summary>
        /// <value>The change password.</value>
        public static string ChangePassword => "ChangePassword";

        /// <summary>
        /// Gets the download personal data.
        /// </summary>
        /// <value>The download personal data.</value>
        public static string DownloadPersonalData => "DownloadPersonalData";

        /// <summary>
        /// Gets the delete personal data.
        /// </summary>
        /// <value>The delete personal data.</value>
        public static string DeletePersonalData => "DeletePersonalData";

        /// <summary>
        /// Gets the external logins.
        /// </summary>
        /// <value>The external logins.</value>
        public static string ExternalLogins => "ExternalLogins";

        /// <summary>
        /// Gets the personal data.
        /// </summary>
        /// <value>The personal data.</value>
        public static string PersonalData => "PersonalData";

        /// <summary>
        /// Gets the two factor authentication.
        /// </summary>
        /// <value>The two factor authentication.</value>
        public static string TwoFactorAuthentication => "TwoFactorAuthentication";

        /// <summary>
        /// Indexes the nav class.
        /// </summary>
        /// <param name="viewContext">The view context.</param>
        /// <returns>System.String.</returns>
        public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index);

        /// <summary>
        /// Changes the password nav class.
        /// </summary>
        /// <param name="viewContext">The view context.</param>
        /// <returns>System.String.</returns>
        public static string ChangePasswordNavClass(ViewContext viewContext) => PageNavClass(viewContext, ChangePassword);

        /// <summary>
        /// Downloads the personal data nav class.
        /// </summary>
        /// <param name="viewContext">The view context.</param>
        /// <returns>System.String.</returns>
        public static string DownloadPersonalDataNavClass(ViewContext viewContext) => PageNavClass(viewContext, DownloadPersonalData);

        /// <summary>
        /// Deletes the personal data nav class.
        /// </summary>
        /// <param name="viewContext">The view context.</param>
        /// <returns>System.String.</returns>
        public static string DeletePersonalDataNavClass(ViewContext viewContext) => PageNavClass(viewContext, DeletePersonalData);

        /// <summary>
        /// Externals the logins nav class.
        /// </summary>
        /// <param name="viewContext">The view context.</param>
        /// <returns>System.String.</returns>
        public static string ExternalLoginsNavClass(ViewContext viewContext) => PageNavClass(viewContext, ExternalLogins);

        /// <summary>
        /// Personals the data nav class.
        /// </summary>
        /// <param name="viewContext">The view context.</param>
        /// <returns>System.String.</returns>
        public static string PersonalDataNavClass(ViewContext viewContext) => PageNavClass(viewContext, PersonalData);

        /// <summary>
        /// Twoes the factor authentication nav class.
        /// </summary>
        /// <param name="viewContext">The view context.</param>
        /// <returns>System.String.</returns>
        public static string TwoFactorAuthenticationNavClass(ViewContext viewContext) => PageNavClass(viewContext, TwoFactorAuthentication);

        /// <summary>
        /// Pages the nav class.
        /// </summary>
        /// <param name="viewContext">The view context.</param>
        /// <param name="page">The page.</param>
        /// <returns>System.String.</returns>
        public static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}
