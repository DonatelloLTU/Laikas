using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TimesheetLaikas.Models
{
    [Table("Employee", Schema = "College")]
    public class Employee : IdentityUser
    {
        public Employee() : base()
        {
        }

        [PersonalData]
        [DisplayName("First Name")]
        public string EMP_FNAME { get; set; }

        [PersonalData]
        [DisplayName("Last Name")]
        public string EMP_LNAME { get; set; }

        [NotMapped]
        [DisplayName("Full Name")]
        public string FULL_NAME => EMP_FNAME + " " + EMP_LNAME;

        //[PersonalData]
        //[DisplayName("Phone Number")]
        //public string EMP_PHONE { get; set; }

        [PersonalData]
        [DisplayName("Address")]
        public string ADDRESS { get; set; }


        [PersonalData]
        [DisplayName("City")]
        public string CITY { get; set; }

        [PersonalData]
        [DisplayName("Zip Code")]
        public string ZIPCODE { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [DisplayName("Pay Rate")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal Payrate { get; set; }

        [Required]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public Department Department { get; set; }

        [NotMapped]
        public List<SelectListItem> Departments { get; set; }

        //[DisplayName("Profile Picture")]
        //  public byte[] ProfilePic { get; set; }

        //public virtual ICollection<EmployeesInDepartment> EmployeesInDepartment { get; set; }
    }
}