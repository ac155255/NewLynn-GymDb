﻿using System;
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

        [DateValidator] //custom attribute. see the dateValidator.cs file fpr implementation
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

        internal static Task<string?> ToListAsync()
        {
            throw new NotImplementedException();
        }
    }


    public enum status { 
    
        Present,
        Absent
    
    }
    

}



