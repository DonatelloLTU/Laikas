using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace TimesheetLaikas.Models
{
    /// <summary>
    /// Class Division.
    /// Implements the <see cref="TimesheetLaikas.Models.EntityBase" />
    /// </summary>
    /// <seealso cref="TimesheetLaikas.Models.EntityBase" />
    public class Division : EntityBase
    {
        /// <summary>
        /// Gets or sets the name of the division.
        /// </summary>
        /// <value>The name of the division.</value>
        [Required]
        [DisplayName("Division Name")]
        public String DivisionName { get; set; }

        /// <summary>
        /// Gets or sets the divsion chair identifier.
        /// </summary>
        /// <value>The divsion chair identifier.</value>
        [DisplayName("Division Chair")]
        public String DivsionChairId { get; set; }

        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        /// <value>The employee.</value>
        [ForeignKey(nameof(DivsionChairId))]
        public Employee Employee { get; set; }

        /// <summary>
        /// Gets or sets the departments.
        /// </summary>
        /// <value>The departments.</value>
        public virtual ICollection<Department> Departments { get; set; }
    }
}