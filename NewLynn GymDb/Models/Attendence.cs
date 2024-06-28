using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NewLynn_GymDb.Controllers;
using NewLynn_GymDb.Models;

namespace NewLynn_GymDb.Models
{
    public class Attendance
    {

        [Display(Name = "Attendance ID ")]
        public int AttendanceID { get; set; }

        [Required(ErrorMessage = "MemberID is required")]

        [Display(Name = "Member ID")]
        [Range(1, int.MaxValue, ErrorMessage = "Member must be a positive integer.")]
        public int MemberID { get; set; }
        

        [Required(ErrorMessage = "Employee is required")]

        [Display(Name = "Employee ID")]
        [Range(1, int.MaxValue, ErrorMessage = "EmployeeID must be a positive integer.")]
        public int EmployeeID { get; set; }

        [DateValidator]
        [Display(Name = "Attendance Date")]
        [Required(ErrorMessage = "AttendanceDate is required")]
        [DataType(DataType.DateTime)]
       
        public DateTime AttendanceDate { get; set; }
        public static ValidationResult ValidateAttendanceDate(DateTime AttendanceDate, ValidationContext context)
        {
            if (AttendanceDate > DateTime.Today)
            {
                return new ValidationResult("Attendance date cannot be in the future.");
            }

            return ValidationResult.Success;
        }

        [Required(ErrorMessage = "Status is required")]
        public status Status { get; set; }
        
       

        public virtual Member Member { get; set; }
        

        public virtual Employee Employee { get; set; }

        //This method ToListAsync is declared as internal and static, intending to return a Task<string?>. However, it currently throws a NotImplementedException, indicating it's not yet implemented and needs to be completed to provide functionality.
        internal static Task<string?> ToListAsync()
        {
            throw new NotImplementedException();
        }
    }

    //This status enum defines two options: Present and Absent, representing different status.
    public enum status { 
    
        Present,
        Absent
    
    }
    

}



