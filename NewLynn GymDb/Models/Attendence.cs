using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewLynn_GymDb.Models
{
    public class Attendence
    {
        public int AttendenceID { get; set; }

        [Required(ErrorMessage = "MemberID is required")]
        public int MemberID { get; set; }

        [Required(ErrorMessage = "EmployeeID is required")]
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "AttendenceDate is required")]
        [DataType(DataType.DateTime)]
        public DateTime AttendenceDate { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; }

        public ICollection<Member> Members { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}

    

