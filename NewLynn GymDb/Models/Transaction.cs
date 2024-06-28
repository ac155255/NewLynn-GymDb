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
        [Display(Name = "Member ID")]
        [Range(1, int.MaxValue, ErrorMessage = "MemberID must be a positive integer.")]
        public int MemberID { get; set; }
        

        [Required(ErrorMessage = "EmployeeID is required")]
        [Display(Name = "Employee ID")]
        [Range(1, int.MaxValue, ErrorMessage = "EmployeeID must be a positive integer.")]
        public int EmployeeID { get; set; }
        

        [Required(ErrorMessage = "Amount is required")]
        [RegularExpression(@"^\$?\d+(\.\d{1,2})?$", ErrorMessage = "Invalid amount format. Use up to 2 decimal places.")]

        public string Amount { get; set; }

        [Required(ErrorMessage = "Payment method is required")]
        [Display(Name = "Payment Method")]
        public PaymentMethod PaymentMethod { get; set; }


        //validation attributes to ensure that the "Transaction Date" field is required, formatted as a date and time, and validated using a custom attribute [dateValidator], which is implemented separately to enforce specific validation rules related to transaction dates.
        [dateValidator]
        [Required(ErrorMessage = "Transaction date is required")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Transaction Date")]


        public DateTime TransactionDate { get; set; }

        //This static method ValidateTransactionDate validates a given TransactionDate against today's date, ensuring it's not in the future, and returns a ValidationResult indicating success or failure with an appropriate message.

        public static ValidationResult ValidateTransactionDate(DateTime TransactionDate, ValidationContext context)
        {
            if (TransactionDate > DateTime.Today)
            {
                return new ValidationResult("Transaction date cannot be in the future.");
            }

            return ValidationResult.Success;
        }


        public virtual Member Member { get; set; }


        public virtual Employee Employee { get; set; }
    }

    //This PaymentMethod enum defines two options: Cash and Card, representing different methods of payment.
    public enum PaymentMethod
    {
        Cash,
        Card
    }
        


}

