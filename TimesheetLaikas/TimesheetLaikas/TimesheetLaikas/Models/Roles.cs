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
    [Table("Roles", Schema = "College")]
    public class Roles : IdentityRole
    {
        public Roles() : base()
        {
        }

        public Roles(string roleName) : base(roleName)
        {
        }

        public PayPeriodTypes? PayPeriodDuration { get; set; }
    }
}