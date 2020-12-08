// ***********************************************************************
// Assembly         : TimesheetLaikas
// Author           : Donatas & Matt
// Created          : 12-06-2020
//
// Last Modified By : Donatas & Matt
// Last Modified On : 12-07-2020
// ***********************************************************************
// <copyright file="Index.cshtml.cs" company="TimesheetLaikas">
//     Copyright (c) HP Inc.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TimesheetLaikas.Models;

namespace TimesheetLaikas.Areas.Identity.Pages.Account.Manage
{
    /// <summary>
    /// Class IndexModel.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.RazorPages.PageModel" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.RazorPages.PageModel" />
    public partial class IndexModel : PageModel
    {
        /// <summary>
        /// The user manager
        /// </summary>
        private readonly UserManager<Employee> _userManager;
        /// <summary>
        /// The sign in manager
        /// </summary>
        private readonly SignInManager<Employee> _signInManager;
        /// <summary>
        /// The email sender
        /// </summary>
        private readonly IEmailSender _emailSender;

        /// <summary>
        /// Initializes a new instance of the <see cref="IndexModel"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <param name="signInManager">The sign in manager.</param>
        /// <param name="emailSender">The email sender.</param>
        public IndexModel(
            UserManager<Employee> userManager,
            SignInManager<Employee> signInManager,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
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
        /// Gets or sets the input.
        /// </summary>
        /// <value>The input.</value>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        /// Class InputModel.
        /// </summary>
        public class InputModel
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

            Input = new InputModel
            {
                Email = email,
                PhoneNumber = user.PhoneNumber,
                FirstName = user.EMP_FNAME,
                LastName = user.EMP_LNAME,
                ADDRESS = user.ADDRESS,
                CITY = user.CITY,
                ZIPCODE = user.ZIPCODE
            };

            IsEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);

            return Page();
        }

        /// <summary>
        /// on post as an asynchronous operation.
        /// </summary>
        /// <returns>IActionResult.</returns>
        /// <exception cref="InvalidOperationException">Unexpected error occurred setting email for user with ID '{userId}'.</exception>
        /// <exception cref="InvalidOperationException">Unexpected error occurred setting phone number for user with ID '{userId}'.</exception>
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var email = await _userManager.GetEmailAsync(user);
            if (Input.Email != email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, Input.Email);
                if (!setEmailResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting email for user with ID '{userId}'.");
                }
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting phone number for user with ID '{userId}'.");
                }
            }

            if (Input.FirstName != user.EMP_FNAME)
            {
                user.EMP_FNAME = Input.FirstName;
            }

            if (Input.LastName != user.EMP_LNAME)
            {
                user.EMP_LNAME = Input.LastName;
            }

            await _userManager.UpdateAsync(user);

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }

        /// <summary>
        /// on post send verification email as an asynchronous operation.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var userId = await _userManager.GetUserIdAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { userId = userId, code = code },
                protocol: Request.Scheme);
            await _emailSender.SendEmailAsync(
                email,
                "Confirm your email",
                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            StatusMessage = "Verification email sent. Please check your email.";
            return RedirectToPage();
        }
    }
}