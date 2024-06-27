using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace NewLynn_GymDb.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(225, ErrorMessage = "The first name field should have a maximum of 255 characters")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[A-Z][a-z\s]*$")]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(225, ErrorMessage = "The last name field should have a maximum of 255 characters")]
        [RegularExpression(@"^[A-Z][a-z\s]*$")]
        [DataType(DataType.Text)]
        [Display(Name = "LastName")]
        public string LastName { get; set; }
    }
}
