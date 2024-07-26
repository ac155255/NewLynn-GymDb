using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NewLynn_GymDb.Controllers;
using NewLynn_GymDb.Models;

namespace NewLynn_GymDb.Models
{
    public class Attendance
    {
        [Display(Name = "Attendance ID")]
        public int AttendanceID { get; set; }

        [Required(ErrorMessage = "Member ID is required")]
        [Display(Name = "Member ID")]
        [Range(1, int.MaxValue, ErrorMessage = "Member must be a positive integer.")]
        public int MemberId { get; set; }

        // Assuming you want to display Member's first name in the UI
        [Display(Name = "Members First Name")]
        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "First name must contain only letters and spaces.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "First Name must be between 3 and 50 characters long.")]
        public string MemberFirstName { get; set; }

        [Required(ErrorMessage = "Employee ID is required")]
        [Display(Name = "Employee ID")]
        [Range(1, int.MaxValue, ErrorMessage = "Employee ID must be a positive integer.")]
        public int EmployeeId { get; set; }

        // Assuming you want to display Employee's first name in the UI
        [Display(Name = "Employee First Name")]
        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "First name must contain only letters and spaces.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "First Name must be between 3 and 50 characters long.")]
        public string EmployeeFirstName { get; set; }

        [DateValidator]
        [Display(Name = "Attendance Date")]
        [Required(ErrorMessage = "Attendance Date is required")]
        [DataType(DataType.DateTime)]
        public DateTime AttendanceDate { get; set; }
        public static ValidationResult ValidateTransactionDate(DateTime AttendanceDate, ValidationContext context)
        {
            if (AttendanceDate > DateTime.Today)
            {
                return new ValidationResult("Attendance date cannot be in the future.");
            }

            return ValidationResult.Success;
        }

        [Required(ErrorMessage = "Status is required")]
        public Status Status { get; set; }

        // Navigation properties
        public virtual Member Member { get; set; }
        public virtual Employee Employee { get; set; }
    }

    // Status enum definition
    public enum Status
    {
        Present,
        Absent
    }

}

