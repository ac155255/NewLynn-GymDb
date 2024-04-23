using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewLynn_GymDb.Models
{
    public class Member
    {
        public int MemberId { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Membership type is required")]
        public string MembershipType { get; set; }

        [Required(ErrorMessage = "Join date is required")]
        [DataType(DataType.Date)]
        public DateTime JoinDate { get; set; }

        [Required(ErrorMessage = "Payment information is required")]
        public string PaymentInformation { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}

