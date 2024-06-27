using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NewLynn_GymDb.Controllers;
using NewLynn_GymDb.Models;

namespace NewLynn_GymDb.Models
{
    public class Transaction
    {
        [Display(Name = "Transaction Id")]
        public int TransactionId { get; set; }

        [Required(ErrorMessage = "MemberID is required")]
        [Display(Name = "Member Id")]
        [Range(1, int.MaxValue, ErrorMessage = "MemberID must be a positive integer.")]
        public int MemberID { get; set; }
        

        [Required(ErrorMessage = "EmployeeID is required")]
        [Display(Name = "Employee Id")]
        [Range(1, int.MaxValue, ErrorMessage = "EmployeeID must be a positive integer.")]
        public int EmployeeID { get; set; }
        

        [Required(ErrorMessage = "Amount is required")]
        [RegularExpression(@"^\$?\d+(\.\d{1,2})?$", ErrorMessage = "Invalid amount format. Use up to 2 decimal places.")]

        public string Amount { get; set; }

        [Required(ErrorMessage = "Payment method is required")]
        [Display(Name = "Payment Method")]
        public PaymentMethod PaymentMethod { get; set; }


        [dateValidator] //custom attribute. see the dateValidator.cs file fpr implementation
        [Required(ErrorMessage = "Transaction date is required")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Transaction Date")]


        public DateTime TransactionDate { get; set; }
        public static ValidationResult ValidateTransactionDate(DateTime TransactionDate, ValidationContext context)
        {
            if (TransactionDate > DateTime.Today)
            {
                return new ValidationResult("Transaction date cannot be in the future.");
            }

            return ValidationResult.Success;
        }


        public ICollection<Member> Members { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }

    public enum PaymentMethod
    {
        Cash,
        Card
    }
        


}

