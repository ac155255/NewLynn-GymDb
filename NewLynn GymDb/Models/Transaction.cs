using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewLynn_GymDb.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }

        [Required(ErrorMessage = "MemberID is required")]
        public int MemberID { get; set; }

        [Required(ErrorMessage = "EmployeeID is required")]
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        // You may want to change the data type of Amount to a numeric type for proper validation
        public string Amount { get; set; }

        [Required(ErrorMessage = "Payment method is required")]
        public string PaymentMethod { get; set; }

        [Required(ErrorMessage = "Transaction date is required")]
        [DataType(DataType.DateTime)]
        public DateTime TransactionDate { get; set; }

        public ICollection<Member> Members { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}

