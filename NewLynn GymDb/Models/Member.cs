using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NewLynn_GymDb.Controllers;
using NewLynn_GymDb.Models;

namespace NewLynn_GymDb.Models
{
    public class Member
    {
        [Display(Name = "Member ID")]

        public int MemberId { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Last name must contain only letters and spaces.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Last Name must be between 3 and 50 characters long.")]

        public string LastName { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "First name must contain only letters and spaces.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "First Name must be between 3 and 50 characters long.")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Address is required")]
        [StringLength(80, MinimumLength = 5, ErrorMessage = "Address must be between 5 and 80 characters.")]
        public string Address { get; set; }

        [Phone]
        [RegularExpression(@"^\+?\d{1,3}[- ]?\(?\d{3}\)?[- ]?\d{3}[- ]?\d{4}$", ErrorMessage = "Invalid phone number format")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }



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

        [Required(ErrorMessage = "Join date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Join Date")]
        [CustomValidation(typeof(Member), nameof(ValidateJoinDate))]
        public DateTime JoinDate { get; set; }

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


        public ICollection<Transaction> Transactions { get; set; }
        public virtual Attendance Attendances { get; set; }

        internal static Task<string?> ToListAsync()
        {
            throw new NotImplementedException();
        }


    }


    public enum PaymentInformation
    {
        Cash,
        Card


    }

    public enum MembershipType
    {


        Weekly,
        Monthly,
        Yearly



    }
}

     

   







