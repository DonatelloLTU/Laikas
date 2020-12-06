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
    public class AccountHomeModel : PageModel
    {
        public AccountHomeModel(
        UserManager<Employee> userManager,
        SignInManager<Employee> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        private readonly UserManager<Employee> _userManager;
        private readonly SignInManager<Employee> _signInManager;

        public class ProfileModel
        {
            [Required]
            [Display(Name = "First Name")]
            [DataType(DataType.Text)]
            public string FirstName { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [PersonalData]
            [Display(Name = "Address")]
            public String ADDRESS { get; set; }

            [PersonalData]
            [Display(Name = "City")]
            public String CITY { get; set; }

            [PersonalData]
            [Display(Name = "Zip Code")]
            public String ZIPCODE { get; set; }
        }

        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public ProfileModel Profile { get; set; }

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