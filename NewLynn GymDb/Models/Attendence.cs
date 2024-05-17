using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewLynn_GymDb.Models
{
    public class Attendance
    {
        public int AttendanceID { get; set; }

        [Required(ErrorMessage = "MemberID is required")]
        public int MemberID { get; set; }

        [Required(ErrorMessage = "EmployeeID is required")]
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "AttendanceDate is required")]
        [DataType(DataType.DateTime)]
        public DateTime AttendanceDate { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; }
       

        public virtual Member Member { get; set; }

        public virtual Employee Employee { get; set; }
    }
}

    

