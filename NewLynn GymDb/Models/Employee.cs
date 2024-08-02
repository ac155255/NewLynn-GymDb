using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Humanizer;
using NewLynn_GymDb.Controllers;
using NewLynn_GymDb.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace NewLynn_GymDb.Models
{
    public class Employee
    {
        // validation attributes to ensure that the "Employee Id" field is displayed with the specified name and requires a positive integer value within the defined range, providing an error message if the input does not meet these criteria.

        [Display(Name = "Employee Id")]
        [Range(1, int.MaxValue, ErrorMessage = "EmployeeID must be a positive integer.")]
        public int EmployeeId { get; set; }

       // validation attributes to the "Last Name" field, ensuring it is required, between 3 and 50 characters long, consists only of letters and spaces, and provides appropriate error messages for invalid input.


       [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Last name must contain only letters and spaces.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Last Name must be between 3 and 50 characters long.")]

        public string? LastName { get; set; }

       // validation attributes to the "First Name" field, ensuring it is required, between 3 and 50 characters long, consists only of letters and spaces, and provides appropriate error messages for invalid input.


       [StringLength(50, MinimumLength = 3, ErrorMessage = "First name must contain only letters and spaces.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "First Name must be between 3 and 50 characters long.")]
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required")]
        public string? FirstName { get; set; }

        //validation attributes to ensure that the "Hire Date" field is required, formatted as a date, and validated using a custom method ValidateHireDate defined in the Employee class to enforce specific business logic or constraints related to hire dates.

        [Required(ErrorMessage = "Hire date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Hire Date")]
        [CustomValidation(typeof(Employee), nameof(ValidateHireDate))]
        public DateTime HireDate { get; set; }

        //This static method ValidateHireDate validates a given HireDate against today's date, ensuring it's not in the future, and returns a ValidationResult indicating success or failure with an appropriate message.
        public static ValidationResult ValidateHireDate(DateTime HireDate, ValidationContext context)
        {
            if (HireDate > DateTime.Today)
            {
                return new ValidationResult("Hire date cannot be in the future.");
            }

            return ValidationResult.Success;
        }

        //validation attributes to ensure that the "Address" field is displayed with the specified name and requires a length between 5 and 80 characters, providing an error message if the input does not meet these criteria.

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
        [[RegularExpression(@"^(0[345679][0-9]{7,8}|02[1-9][0-9]{7,8})$", ErrorMessage = "Invalid New Zealand phone number format")]
        public string PhoneNumber { get; set; }

        // validation attributes to the "Salary" field, ensuring it is displayed with the specified name, required, and formatted as a valid monetary amount with up to two decimal places, providing an error message for incorrect formats.

        [Display(Name = "Salary")]
        [RegularExpression(@"^\$?\d+(\.\d{1,2})?$", ErrorMessage = "Invalid salary format. Use up to 2 decimal places.")]
        [Required(ErrorMessage = "Salary is required")]

        public string Salary { get; set; }

        //a virtual property Transactions of type Transaction, allowing for navigation to related transaction data in an entity framework context.
        public virtual Transaction Transactions { get; set; }

        //a virtual navigation property Attendances of type Attendance, allowing for navigation to related attendance data within an entity framework context.
        public virtual Attendance Attendances { get; set; }
    }

    //This Position enum defines four options: Receptionist, Manager, Cleaner, and Trainer, representing different roles or positions within an organization.
    public enum Position
    {
        Receptionist,
        Manager,
        Cleaner,
        Trainer
    }

}








