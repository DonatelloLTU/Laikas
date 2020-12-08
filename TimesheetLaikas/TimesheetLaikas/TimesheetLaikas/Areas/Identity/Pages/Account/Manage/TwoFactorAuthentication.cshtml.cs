// ***********************************************************************
// Assembly         : TimesheetLaikas
// Author           : Donatas & Matt
// Created          : 12-06-2020
//
// Last Modified By : Donatas & Matt
// Last Modified On : 12-07-2020
// ***********************************************************************
// <copyright file="TwoFactorAuthentication.cshtml.cs" company="TimesheetLaikas">
//     Copyright (c) HP Inc.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TimesheetLaikas.Models;
namespace TimesheetLaikas.Areas.Identity.Pages.Account.Manage
{
    /// <summary>
    /// Class TwoFactorAuthenticationModel.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.RazorPages.PageModel" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.RazorPages.PageModel" />
    public class TwoFactorAuthenticationModel : PageModel
    {
        /// <summary>
        /// The authenicator URI format
        /// </summary>
        private const string AuthenicatorUriFormat = "otpauth://totp/{0}:{1}?secret={2}&issuer={0}";

        /// <summary>
        /// The user manager
        /// </summary>
        private readonly UserManager<Employee> _userManager;
        /// <summary>
        /// The sign in manager
        /// </summary>
        private readonly SignInManager<Employee> _signInManager;
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<TwoFactorAuthenticationModel> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="TwoFactorAuthenticationModel"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <param name="signInManager">The sign in manager.</param>
        /// <param name="logger">The logger.</param>
        public TwoFactorAuthenticationModel(
            UserManager<Employee> userManager,
            SignInManager<Employee> signInManager,
            ILogger<TwoFactorAuthenticationModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has authenticator.
        /// </summary>
        /// <value><c>true</c> if this instance has authenticator; otherwise, <c>false</c>.</value>
        public bool HasAuthenticator { get; set; }

        /// <summary>
        /// Gets or sets the recovery codes left.
        /// </summary>
        /// <value>The recovery codes left.</value>
        public int RecoveryCodesLeft { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is2fa enabled].
        /// </summary>
        /// <value><c>true</c> if [is2fa enabled]; otherwise, <c>false</c>.</value>
        [BindProperty]
        public bool Is2faEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is machine remembered.
        /// </summary>
        /// <value><c>true</c> if this instance is machine remembered; otherwise, <c>false</c>.</value>
        public bool IsMachineRemembered { get; set; }

        /// <summary>
        /// Gets or sets the status message.
        /// </summary>
        /// <value>The status message.</value>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        /// Called when [get].
        /// </summary>
        /// <returns>IActionResult.</returns>
        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            HasAuthenticator = await _userManager.GetAuthenticatorKeyAsync(user) != null;
            Is2faEnabled = await _userManager.GetTwoFactorEnabledAsync(user);
            IsMachineRemembered = await _signInManager.IsTwoFactorClientRememberedAsync(user);
            RecoveryCodesLeft = await _userManager.CountRecoveryCodesAsync(user);

            return Page();
        }

        /// <summary>
        /// Called when [post].
        /// </summary>
        /// <returns>IActionResult.</returns>
        public async Task<IActionResult> OnPost()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await _signInManager.ForgetTwoFactorClientAsync();
            StatusMessage = "The current browser has been forgotten. When you login again from this browser you will be prompted for your 2fa code.";
            return RedirectToPage();
        }
    }
}