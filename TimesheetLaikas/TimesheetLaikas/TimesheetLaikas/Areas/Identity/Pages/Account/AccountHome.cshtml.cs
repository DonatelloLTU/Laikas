// ***********************************************************************
// Assembly         : TimesheetLaikas
// Author           : Donatas & Matt
// Created          : 12-06-2020
//
// Last Modified By : Donatas & Matt
// Last Modified On : 12-07-2020
// ***********************************************************************
// <copyright file="AccountHome.cshtml.cs" company="TimesheetLaikas">
//     Copyright (c) HP Inc.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TimesheetLaikas.Models;

namespace TimesheetLaikas.Areas.Identity.Pages.Account
{
    /// <summary>
    /// Class AccountHomeModel.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.RazorPages.PageModel" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.RazorPages.PageModel" />
    public class AccountHomeModel : PageModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountHomeModel"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <param name="signInManager">The sign in manager.</param>
        public AccountHomeModel(
        UserManager<Employee> userManager,
        SignInManager<Employee> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        /// The user manager
        /// </summary>
        private readonly UserManager<Employee> _userManager;
        /// <summary>
        /// The sign in manager
        /// </summary>
        private readonly SignInManager<Employee> _signInManager;

        /// <summary>
        /// Class ProfileModel.
        /// </summary>
        public class ProfileModel
        {
            /// <summary>
            /// Gets or sets the first name.
            /// </summary>
            /// <value>The first name.</value>
            [Required]
            [Display(Name = "First Name")]
            [DataType(DataType.Text)]
            public string FirstName { get; set; }

            /// <summary>
            /// Gets or sets the last name.
            /// </summary>
            /// <value>The last name.</value>
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            /// <summary>
            /// Gets or sets the email.
            /// </summary>
            /// <value>The email.</value>
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            /// <summary>
            /// Gets or sets the phone number.
            /// </summary>
            /// <value>The phone number.</value>
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            /// <summary>
            /// Gets or sets the address.
            /// </summary>
            /// <value>The address.</value>
            [PersonalData]
            [Display(Name = "Address")]
            public String ADDRESS { get; set; }

            /// <summary>
            /// Gets or sets the city.
            /// </summary>
            /// <value>The city.</value>
            [PersonalData]
            [Display(Name = "City")]
            public String CITY { get; set; }

            /// <summary>
            /// Gets or sets the zipcode.
            /// </summary>
            /// <value>The zipcode.</value>
            [PersonalData]
            [Display(Name = "Zip Code")]
            public String ZIPCODE { get; set; }
        }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is email confirmed.
        /// </summary>
        /// <value><c>true</c> if this instance is email confirmed; otherwise, <c>false</c>.</value>
        public bool IsEmailConfirmed { get; set; }

        /// <summary>
        /// Gets or sets the status message.
        /// </summary>
        /// <value>The status message.</value>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        /// Gets or sets the profile.
        /// </summary>
        /// <value>The profile.</value>
        [BindProperty]
        public ProfileModel Profile { get; set; }

        /// <summary>
        /// on get as an asynchronous operation.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var userName = await _userManager.GetUserNameAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Profile = new ProfileModel
            {
                Email = email,
                PhoneNumber = user.PhoneNumber,
                FirstName = user.EMP_FNAME,
                LastName = user.EMP_LNAME,
                ADDRESS = user.ADDRESS,
                CITY = user.CITY,
                ZIPCODE = user.ZIPCODE
            };

            return Page();
        }
    }
}