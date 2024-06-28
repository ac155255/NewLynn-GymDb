using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Humanizer;
using NewLynn_GymDb.Controllers;
using NewLynn_GymDb.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace NewLynn_GymDb.Models
{
    public class Member
    {
        [Display(Name = "Member ID")]

        public int MemberId { get; set; }

        //validation attributes to enforce requirements for the "Last Name" field, including length constraints, character composition, and error messages for invalid inpu

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Last name must contain only letters and spaces.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Last Name must be between 3 and 50 characters long.")]
        public string LastName { get; set; }

        //validation attributes to enforce requirements for the "First Name" field, including length constraints, character composition, and error messages for invalid inpu

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "First name must contain only letters and spaces.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "First Name must be between 3 and 50 characters long.")]
        public string FirstName { get; set; }

        // validation attributes to ensure that the "Address" field is required, and its length falls between 5 and 80 characters, displaying appropriate error messages for invalid input.

        [Required(ErrorMessage = "Address is required")]
        [StringLength(80, MinimumLength = 5, ErrorMessage = "Address must be between 5 and 80 characters.")]
        public string Address { get; set; }

        // validation attributes to ensure that the "Phone Number" field meets criteria for a valid phone number format, displaying an error message if the format is invalid.

        [Phone]
        [RegularExpression(@"^\+?\d{1,3}[- ]?\(?\d{3}\)?[- ]?\d{3}[- ]?\d{4}$", ErrorMessage = "Invalid phone number format")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        //validation attributes to ensure that the "Email" field is required and must be a valid email address format, providing appropriate error messages for missing or invalid entries.

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        
        [Required(ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]

        public DateTime DateOfBirth { get; set; }


        [Required(ErrorMessage = "Membership type is required")]
        [Display(Name = "Membership Type")]
        public MembershipType MembershipType { get; set; }

        //validation attributes to ensure that the "Join Date" field is required, formatted as a date, and validated using a custom method ValidateJoinDate defined in the Member class to ensure it's not in the future.

        [Required(ErrorMessage = "Join date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Join Date")]
        [CustomValidation(typeof(Member), nameof(ValidateJoinDate))]
        public DateTime JoinDate { get; set; }

        //This static method ValidateJoinDate validates a given joinDate against today's date, ensuring it's not in the future, and returns a ValidationResult indicating success or failure with an appropriate message.
        public static ValidationResult ValidateJoinDate(DateTime joinDate, ValidationContext context)
        {
            if (joinDate > DateTime.Today)
            {
                return new ValidationResult("Join date cannot be in the future.");
            }

            return ValidationResult.Success;
        }
    


        [Required(ErrorMessage = "Payment information is required")]
        [Display(Name = "Payment Information")]
        public PaymentInformation PaymentInformation { get; set; }

        //a virtual property Transactions of type Transaction, allowing for navigation to related transaction data in an entity framework context.
        public virtual Transaction Transactions { get; set; }

        //a virtual navigation property Attendances of type Attendance, allowing for navigation to related attendance data within an entity framework context.
        public virtual Attendance Attendances { get; set; }

        internal static Task<string?> ToListAsync()
        {
            throw new NotImplementedException();
        }


    }


    //This PaymentInformation enum defines two options: Cash and Card, representing different methods of payment.
    public enum PaymentInformation
    {
        Cash,
        Card


    }

    //This MembershipType enum defines three options: Weekly, Monthly, and Yearly, representing different durations or types of memberships.
    public enum MembershipType
    {


        Weekly,
        Monthly,
        Yearly



    }
}

     

   







