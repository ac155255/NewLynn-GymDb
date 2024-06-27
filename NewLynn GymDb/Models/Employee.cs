using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NewLynn_GymDb.Controllers;
using NewLynn_GymDb.Models;

namespace NewLynn_GymDb.Models
{
    public class Employee
    {
        [Display(Name = "Employee Id")]
        [Range(1, int.MaxValue, ErrorMessage = "EmployeeID must be a positive integer.")]
        public int EmployeeId { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Last name must contain only letters and spaces.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Last Name must be between 3 and 50 characters long.")]

        public string? LastName { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "First name must contain only letters and spaces.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "First Name must be between 3 and 50 characters long.")]
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required")]
        public string? FirstName { get; set; }

        [Display(Name = "Hire Date")]
        [Required(ErrorMessage = "Hire date is required")]

        [DateValidator] //custom attribute. see the dateValidator.cs file fpr implementation]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(Employee), nameof(HireDate))]
        public DateTime HireDate { get; set; }
        
        public static ValidationResult ValidateHireDate(DateTime HireDate, ValidationContext context)
        {
            if (HireDate > DateTime.Today)
            {
                return new ValidationResult("Hire date cannot be in the future.");
            }

            return ValidationResult.Success;
        }

        [Display(Name = "Address")]
        [StringLength(80, MinimumLength = 5, ErrorMessage = "Address must be between 5 and 80 characters.")]
        public string? Address { get; set; }
        [Display(Name = "Position")]
        [Required(ErrorMessage = "Position is required")]
        public Position Position { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^\+?\d{1,3}[- ]?\(?\d{3}\)?[- ]?\d{3}[- ]?\d{4}$", ErrorMessage = "Invalid phone number format")]
        public string PhoneNumber { get; set; }


        [Display(Name = "Salary")]
        [RegularExpression(@"^\$?\d+(\.\d{1,2})?$", ErrorMessage = "Invalid salary format. Use up to 2 decimal places.")]
        [Required(ErrorMessage = "Salary is required")]

        public string Salary { get; set; }

        public ICollection<Attendance> Attendances { get; set; }
    }
    public enum Position
    {
        Receptionist,
        Manager,
        Cleaner,
        Trainer
    }

}








