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
    public class UserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        //[DisplayName("Profile Picture")]
        //public byte[] ProfilePic { get; set; }

        [PersonalData]
        [DisplayName("Phone Number")]
        public String EMP_PHONE { get; set; }

        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The new password and confirmation password do not match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [PersonalData]
        [DisplayName("First Name")]
        public string EMP_FNAME { get; set; }

        [PersonalData]
        [DisplayName("Last Name")]
        public string EMP_LNAME { get; set; }

        [PersonalData]
        [DisplayName("Address")]
        public string ADDRESS { get; set; }

        

        [NotMapped]
        public List<SelectListItem> States { get; set; }

        [PersonalData]
        [DisplayName("City")]
        public string CITY { get; set; }

        [PersonalData]
        [DisplayName("Zip Code")]
        public string ZIPCODE { get; set; }

        public string Email { get; set; }

        [NotMapped]
        public List<SelectListItem> ApplicationRoles { get; set; }

        [Display(Name = "Position")]
        public string RoleId { get; set; }

        

        [DisplayName("Pay Rate")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal Payrate { get; set; }
    }
}