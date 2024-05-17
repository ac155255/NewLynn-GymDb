using System;
using System.ComponentModel.DataAnnotations;

namespace NewLynn_GymDb.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Hire date is required")]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        public string? Address { get; set; }

        [Required(ErrorMessage = "Position is required")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [RegularExpression(@"^\+?\d{0,9}\d{1,14}", ErrorMessage = "Invalid phone number format")]
        public string PhoneNumber { get; set; }
        

        [Required(ErrorMessage = "Salary is required")]
      
        public string Salary { get; set; }
       
       public ICollection<Attendance> Attendances { get; set; }
    }
}


        
    

    

